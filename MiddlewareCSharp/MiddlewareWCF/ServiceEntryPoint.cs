using ContractWCF;
using System;
using System.Security.Permissions;

namespace MiddlewareWCF
{
    public class ServiceEntryPoint : IServiceEntryPoint
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Message AccessService(Message message)
        {
            Message response = new Message();

            if (!CheckAppToken(message.appToken))
            {
                response.info = "Wrong app token : \"" + message.appToken + "\"";
                response.operationStatus = false;

                logger.Info("Wrong app token : " + message.appToken);
            }
            else
            {
                logger.Info("Dispatch client request for service : " + message.operationName);
                response = DispatchToService(message);
            }

            return response;
        }

        private bool CheckAppToken(string appToken)
        {
            bool isAppTokenValid;

            if (appToken == "client" || appToken == "java")
            {
                isAppTokenValid = true;
            }
            else
            {
                isAppTokenValid = false;
            }

            return isAppTokenValid;
        }

        private Message DispatchToService(Message message)
        {
            IService service;
            switch (message.operationName)
            {
                case "serviceRegister":
                    service = new ServiceRegister();
                    break;
                case "serviceLogin":
                    service = new ServiceLogin();
                    break;
                case "serviceLogout":
                    service = new ServiceLogout();
                    break;
                case "serviceDecrypt":
                    service = new ServiceDecrypt();
                    break;
                case "serviceJEEResponse":
                    service = new ServiceDecrypt();
                    break;
                default:
                    logger.Info("Unknown web service : " + message.operationName);
                    return new Message
                    {
                        info = "Invalid operatioName : \"" + message.operationName + "\"",
                        operationStatus = false
                    };
            }

            return service.ExecuteService(message);
        }
    }
}
