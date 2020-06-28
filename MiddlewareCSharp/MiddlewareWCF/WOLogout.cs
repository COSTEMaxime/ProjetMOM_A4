using ContractWCF;
using DAL;
using System;

namespace MiddlewareWCF
{
    class WOLogout : IWorkflowOrchestrator
    {
        public Message Execute(Message message)
        {
            string login;

            try
            {
                login = (string)message.data[0];
            }
            catch (Exception)
            {
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            UserEntity user = DAO.GetInstance().GetUserByLogin(login);
            user.Token = "";

            return new Message
            {
                operationStatus = DAO.GetInstance().SaveChanges()
            };
        }
    }
}