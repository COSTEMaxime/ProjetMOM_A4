using ContractWCF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class WORegister : IWorkflowOrchestrator
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Message Execute(Message message)
        {
            BLRegister bLRegister = new BLRegister();

            string login, password, email;
            List<string> groups;

            try
            {
                login = (string)message.data[0];
                password = (string)message.data[1];
                email = (string)message.data[2];
                groups = ((List<string>)message.data[3]);
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

            if (bLRegister.IsLoginUsed(login))
            {
                logger.Info("Login already used : \"" + login + "\"");
                return new Message
                {
                    info = "Login already used : \"" + login + "\"",
                    operationStatus = false
                };
            }

            if (!bLRegister.Register(login, password, email, groups))
            {
                logger.Error("Could not create user : \"" + login + "\"; database error ?");
                return new Message
                {
                    info = "Could not create user : \"" + login + "\"",
                    operationStatus = false
                };
            }

            BLEmail blEmail = new BLEmail();
            MailMessage mail = blEmail.CreateMailMessage("Welcome !", $"Thanks for creating an account {login}");
            blEmail.SendEmail(email, mail);


            logger.Info("Created user : \"" + login + "\"");
            return new Message
            {
                info = "Created user: \"" + login + "\"",
                operationStatus = true
            };
        }
    }
}
