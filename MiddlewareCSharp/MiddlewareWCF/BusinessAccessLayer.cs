using ContractWCF;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BusinessAccessLayer
    {
        static public Message Dispatch(Message message)
        {
            // TODO: add logs

            // can't authenticate user if he is creating an account / login
            if (message.operationName != "serviceRegister"
                && message.operationName != "serviceLogin"
                && message.operationName != "serviceJEEResponse")
            {
                var authorisationStatus = BusinessAccessLayer.CheckAuthorisation(message);
                if (!authorisationStatus.Item1)
                {
                    return new Message
                    {
                        info = "You don't have access to this service : " + authorisationStatus.Item2,
                        operationStatus = false
                    };
                }
            }

            IWorkflowOrchestrator workflowOrchestrator;

            switch(message.operationName)
            {
                case "serviceRegister":
                    workflowOrchestrator = new WORegister();
                    break;
                case "serviceLogin":
                    workflowOrchestrator = new WOLogin();
                    break;
                case "serviceDecrypt":
                    workflowOrchestrator = new WODecrypt();
                    break;
                case "serviceJEEResponse":
                    workflowOrchestrator = new WOJEEResponse();
                    break;
                default:
                    throw new Exception("WorkflowOrchestrator \"" + message.operationName +"\" does not exists");
            }

            return workflowOrchestrator.Execute(message);
        }

        static private Tuple<bool, string> CheckAuthorisation(Message message)
        {
            string info = "";
            bool success = false;

            string login = (string)message.data[0];
            if (CheckUserToken(login, message.userToken))
            {
                if (CheckUserPermissions(login, message.operationName))
                {
                    success = true;
                }
                else
                {
                    info = "You don't have the right to access this service : \"" + message.operationName + "\"";
                }
            }
            else
            {
                info = "Invalid UserToken";
            }

            return new Tuple<bool, string>(success, info);
        }

        static private bool CheckUserToken(string login, string token)
        {
            if (token == "" || token == null) { return false; }
            return DAO.GetInstance().GetUserByLogin(login)?.Token == token;
        }

        static private bool CheckUserPermissions(string login, string operatioName)
        {
            // get user groups
            ICollection<UserGroupEntity> userGroups = DAO.GetInstance().GetUserByLogin(login).Groups;
            foreach(UserGroupEntity userGroup in userGroups)
            {
                // get permission for each this user group
                ICollection<GroupServiceEntity> availableServices = DAO.GetInstance().GetServicesFromGroup(userGroup.Group);
                foreach(GroupServiceEntity availableService in availableServices)
                {
                    if (availableService.Service.ServiceName == operatioName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
