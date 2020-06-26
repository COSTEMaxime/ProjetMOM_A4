using ContractWCF;
using DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiddlewareWCF
{
    class WODecrypt : IWorkflowOrchestrator
    {
        private static readonly string URl = "http://localhost:14080/CheckerService/CheckerServiceBean";
        private static readonly string ACTION = "http://localhost:14080/CheckerService/CheckerServiceBean?Tester";

        public static IDictionary<string, EventWaitHandle> SecretFound = new Dictionary<string, EventWaitHandle>();
        public static IDictionary<string, object[]> horribleList = new Dictionary<string, object[]>();
        private static int CPuCoreCount
        {
            get
            {
                return Environment.ProcessorCount;
            }
        }

        public Message Execute(Message message)
        {
            // start new thread ?
            Dictionary<string, string> documents;
            try
            {
                documents = (Dictionary<string, string>)message.data[0];
            }
            catch (Exception)
            {
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }

            bool secretFound = false;

            string guuid = Guid.NewGuid().ToString();
            List<BLDecrypt> decryptors = new List<BLDecrypt>();
            foreach (var document in documents)
            {
                decryptors.Add(new BLDecrypt(document.Key, document.Value));
            }
            SecretFound[guuid] = new EventWaitHandle(false, EventResetMode.AutoReset);
            new Thread(() =>
            {
                SecretFound[guuid].WaitOne();
                secretFound = true;
            }).Start();

            int keyCount = BLDecrypt.MinKey;
            while (!secretFound && keyCount < BLDecrypt.MaxKey)
            {
                string key = BLDecrypt.GetKey(keyCount);

                Parallel.ForEach(decryptors, new ParallelOptions { MaxDegreeOfParallelism = WODecrypt.CPuCoreCount }, blDecrypt =>
                {
                    string documentDecypher = blDecrypt.DecypherDocument(key);

                    BLJEEMessage bLJEEMessage = new BLJEEMessage(WODecrypt.URl, WODecrypt.ACTION);
                    Message payload = new Message
                    {
                        appToken = "middlewareCSharp",
                        data = new object[] { blDecrypt.DocumentName, key, guuid, documentDecypher }
                    };

                    bLJEEMessage.PrepareAndSendMessage(message);
                });
            }

            while (!secretFound)
            {
                // active wait
                // TODO: will we ever get a response ?
            }

            // get entry that starts with guuid
            // remove event
            object[] test = horribleList[guuid];
            SecretFound.Remove(guuid);
            horribleList.Remove(guuid);

            //string documentName, key, guuid, documentDecypher, secret, confidence;

            //try
            //{
            //    documentName = (string)message.data[0];
            //    key = (string)message.data[1];
            //    guuid = (string)message.data[2];
            //    documentDecypher = (string)message.data[3];
            //    secret = (string)message.data[4];
            //    confidence = (string)message.data[4];
            //}
            //catch (Exception)
            //{
            //    return new Message
            //    {
            //        info = "Malformed message",
            //        operationStatus = false
            //    };
            //}

            // generate pdf
            // send mail
            return new Message
            {
                operationStatus = true,
                data = test
            };

            //foreach (var document in documents)
            //{
            //    // error if tested all keys
            //    Parallel.For(BLDecrypt.MinKey, BLDecrypt.MaxKey, new ParallelOptions { MaxDegreeOfParallelism = WODecrypt.CPuCoreCount }, i =>
            //    {
            //        string key = bLDecrypt.GetKey(i);
            //        string documentDecypher = bLDecrypt.DecypherDocument(key);

            //        BLJEEMessage bLJEEMessage = new BLJEEMessage(WODecrypt.URl, WODecrypt.ACTION);
            //        Message payload = new Message
            //        {
            //            appToken = "middlewareCSharp",
            //            data = new object[] { documentDecypher, document.Key, }
            //        };

            //        bLJEEMessage.PrepareAndSendMessage(message);
            //    });

            //while (i < BLDecrypt.MaxKey)
            //{
            //    string key = bLDecrypt.GetKey(i);
            //    string documentDecypher = bLDecrypt.DecypherDocument(key);

            //    BLJEEMessage bLJEEMessage = new BLJEEMessage(WODecrypt.URl, WODecrypt.ACTION);
            //    Message payload = new Message
            //    {
            //        appToken = "middlewareCSharp",
            //        data = new object[] { documentDecypher, document.Key,  }
            //    };
            //}
            //}
        }
    }
}
