using ContractWCF;
using System;
using System.Security.Permissions;

namespace MiddlewareWCF
{
    public class ServiceEntryPoint : IServiceEntryPoint
    {
        public Message AccessService(Message message)
        {
            Message response = new Message();

            if (!CheckAppToken(message.appToken))
            {
                response.info = "Wrong app token : \"" + message.appToken + "\"";
                response.operationStatus = false;
            }
            else
            {
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
                case "serviceDecrypt":
                    service = new ServiceDecrypt();
                    break;
                case "serviceJEEResponse":
                    service = new ServiceDecrypt();
                    break;
                default:
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
