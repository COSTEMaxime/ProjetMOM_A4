using ContractWCF;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class WODecrypt : IWorkflowOrchestrator
    {
        private static readonly string URl = "http://localhost:14080/CheckerService/CheckerServiceBean";
        private static readonly string ACTION = "http://localhost:14080/CheckerService/CheckerServiceBean?Tester";

        public Message Execute(Message message)
        {
            // start new thread ?
            // create this inside a loop
            BLDecrypt bLDecrypt = new BLDecrypt();
            BLJEEMessage bLJEEMessage = new BLJEEMessage(WODecrypt.URl, WODecrypt.ACTION);

            Message messageJEE = new Message
            {
                appToken = "middlewareCSharp",
                // data = new object[] { key, documentName, document }
            };

            bLJEEMessage.PrepareAndSendMessage(messageJEE);


            return message;
        }
    }
}
