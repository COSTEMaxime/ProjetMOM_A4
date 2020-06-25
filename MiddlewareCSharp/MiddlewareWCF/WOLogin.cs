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
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            BLLogin blLogin = new BLLogin();

            if (blLogin.Login(login, password))
            {
                return new Message
                {
                    info = "Success (login)",
                    operationStatus = true
                };
            }
            else
            {
                return new Message
                {
                    info = "Login failed (invalid login or password)",
                    operationStatus = false
                };
            }
        }
    }
}
