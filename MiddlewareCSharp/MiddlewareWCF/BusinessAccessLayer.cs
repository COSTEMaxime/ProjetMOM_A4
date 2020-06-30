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
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        static public Message Dispatch(Message message)
        {
            // can't authenticate user if he is creating an account / login
            if (message.operationName != "serviceRegister"
                && message.operationName != "serviceLogin"
                && message.operationName != "serviceJEEResponse")
            {
                var authorisationStatus = BusinessAccessLayer.CheckAuthorisation(message);
                if (!authorisationStatus.Item1)
                {
                    logger.Info("Denied service access : " + authorisationStatus.Item2);
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
                case "serviceLogout":
                    workflowOrchestrator = new WOLogout();
                    break;
                case "serviceDecrypt":
                    workflowOrchestrator = new WODecrypt();
                    break;
                case "serviceJEEResponse":
                    workflowOrchestrator = new WOJEEResponse();
                    break;
                default:
                    logger.Error("Workflow orchestrator not found : \"" + message.operationName + "\"");
                    throw new Exception("WorkflowOrchestrator \"" + message.operationName +"\" does not exists");
            }

            logger.Info("Authorized service access to user : \"" + message.data[0] + "\", requested service service : \"" + message.operationName + "\"");
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

            try
            {
                byte[] data = Convert.FromBase64String(token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when < DateTime.UtcNow.AddHours(-1))
                {
                    // expired token
                    logger.Info("User tried to connect with an expired token. Creation date was : " + when.ToLongDateString());
                    return false;
                }
            }
            catch (Exception)
            {
                // malformed token
                logger.Info("User tried to connect with a malformed token : \"" + token + "\"");
                return false;
            }

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

            logger.Info("Denied access to service : \"" + operatioName + "\" for user : \"" + login + "\"");
            return false;
        }
    }
}
