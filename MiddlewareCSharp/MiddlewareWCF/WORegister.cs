using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class WORegister : IWorkflowOrchestrator
    {
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
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            if (bLRegister.IsLoginUsed(login))
            {
                return new Message
                {
                    info = "Login already used : \"" + login + "\"",
                    operationStatus = false
                };
            }

            if (!bLRegister.Register(login, password, email, groups))
            {
                return new Message
                {
                    info = "Could not create user : \"" + login + "\"",
                    operationStatus = false
                };
            }

            return new Message
            {
                info = "Created user: \"" + login + "\"",
                operationStatus = true
            };
        }
    }
}
