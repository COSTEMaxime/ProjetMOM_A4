using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class WOLogin : IWorkflowOrchestrator
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Message Execute(Message message)
        {
            string login, password;

            try
            {
                login = (string)message.data[0];
                password = (string)message.data[1];
            }
            catch (Exception)
            {
                logger.Info("Malformed mesage : " + message);
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            BLLogin blLogin = new BLLogin();
            if (blLogin.Login(login, password))
            {
                logger.Info("Logged user : \"" + login +"\"");
                return new Message
                {
                    info = "Success (login)",
                    operationStatus = true,
                    data = new object[] { blLogin.Token }
                };
            }
            else
            {
                logger.Info("Wrong username / password for user : \"" + login + "\"");
                return new Message
                {
                    info = "Login failed (invalid login or password)",
                    operationStatus = false
                };
            }
        }
    }
}
