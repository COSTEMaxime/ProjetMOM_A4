using ContractWCF;
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
            // can't authenticate user if he is creating an account / login


            // rework this
            if (message.operationName != "serviceRegister" && message.operationName != "serviceLogin")
            {
                if (!BusinessAccessLayer.CheckAuthorisation(message))
                {
                    return new Message
                    {
                        info = "You don't have access to this service : " + message.appVersion,
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
                default:
                    throw new Exception("WorkflowOrchestrator \"" + message.operationName +"\" does not exists");
            }

            return workflowOrchestrator.Execute(message);
        }

        static private bool CheckAuthorisation(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
