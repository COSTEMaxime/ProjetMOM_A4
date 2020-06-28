using ContractWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class WOJEEResponse : IWorkflowOrchestrator
    {
        public Message Execute(Message message)
        {
            string guuid;

            try
            {
                guuid = (string)message.data[2];
            }
            catch (Exception)
            {
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            WODecrypt.horribleList[guuid] = message.data;
            WODecrypt.SecretFound[guuid].Set();

            return new Message
            {
                operationStatus = true
            };
        }
            //        bLJEEMessage.PrepareAndSendMessage(payload, (IAsyncResult result) =>
            //                    {
            //                        XElement messageNode:
            //                        using (WebResponse webResponse = bLJEEMessage.WebRequest.EndGetResponse(result))
            //                        {
            //                            using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
            //                            {
            //                                XDocument xmlResponse = XDocument.Load(rd);
            //    messageNode = xmlResponse.Descendants("message").First();
            //}
            //                        }

            //                        Message response = bLJEEMessage.Deserialize<Message>(messageNode.Value);
            //                        // check in response
            //                    });
        }
}
