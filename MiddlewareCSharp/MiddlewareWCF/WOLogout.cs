using ContractWCF;
using DAL;
using System;

namespace MiddlewareWCF
{
    class WOLogout : IWorkflowOrchestrator
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Message Execute(Message message)
        {
            string login;

            try
            {
                login = (string)message.data[0];
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

            bool status = new BLLogout().Logout(login);

            if (status)
            {
                logger.Info("Logged out user : \"" + login + "\"");
            }
            else
            {
                logger.Error("Could not log out user : \"" + login + "\"");
            }

            return new Message
            {
                operationStatus = status
            };
        }
    }
}