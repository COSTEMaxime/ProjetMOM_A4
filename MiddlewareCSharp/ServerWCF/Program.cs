﻿using DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupLogger();

            ServiceHost host = new ServiceHost(typeof(MiddlewareWCF.ServiceEntryPoint));
            Console.WriteLine("Starting up server....");

            try
            {
                host.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                host.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine(ce.Message);
                host.Abort();
            }
        }

        private static void SetupLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            // Where to lo to: File & Console
            var logFile = new NLog.Targets.FileTarget("logFile") { FileName = "server.log" };
            var logConsole = new NLog.Targets.ConsoleTarget("logConsole");
            // Logging rules (where to log what)
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logConsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);

            LogManager.Configuration = config;
        }
    }
}
