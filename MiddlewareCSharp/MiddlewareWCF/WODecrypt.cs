using ContractWCF;
using DAL;
using MiddlewareWCF.JavaEEService;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiddlewareWCF
{
    class WODecrypt : IWorkflowOrchestrator
    {
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
            Dictionary<string, byte[]> documents;
            string userLogin;
            try
            {
                userLogin = (string)message.data[0];
                documents = (Dictionary<string, byte[]>)message.data[1];
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

            List<Tuple<BLDecrypt, BLJEEMessage>> decryptorsClients = new List<Tuple<BLDecrypt, BLJEEMessage>>();
            foreach (var document in documents)
            {
                decryptorsClients.Add(new Tuple<BLDecrypt, BLJEEMessage>(
                    new BLDecrypt(document.Key, System.Text.Encoding.UTF8.GetString(document.Value)),
                    new BLJEEMessage()
                ));
            }

            string guuid = Guid.NewGuid().ToString();
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

                Parallel.ForEach(decryptorsClients, new ParallelOptions { MaxDegreeOfParallelism = WODecrypt.CPuCoreCount }, decryptorClient =>
                {
                    string documentDecypher = decryptorClient.Item1.DecypherDocument(key);

                    msg requestMsg = new msg()
                    {
                        appToken = "middlewareCSharp",
                        data = new object[] { decryptorClient.Item1.DocumentName, key, guuid, Encoding.UTF8.GetBytes(documentDecypher) }
                    };

                    _ = decryptorClient.Item2.SendMessageAsync(requestMsg);
                });

                keyCount++;
            }

            while (!secretFound)
            {
                // active wait
                // TODO: will we ever get a response ?
            }

            // get entry that starts with guuid
            // remove event
            object[] response = horribleList[guuid];

            string documentName, keyResponse, secret;
            float confidence;

            try
            {
                documentName = (string)message.data[0];
                keyResponse = (string)message.data[1];
                secret = (string)message.data[3];
                confidence = (float)message.data[4];
            }
            catch (Exception)
            {
                return new Message
                {
                    info = "Malformed message",
                    operationStatus = false
                };
            }
            SecretFound.Remove(guuid);
            horribleList.Remove(guuid);

            BLPDF bLPDF = new BLPDF();
            using (Stream stream = bLPDF.GeneratePDF(confidence, documentName, keyResponse, secret))
            {
                BLEmail bLEmail = new BLEmail();
                MailMessage mailMessage = bLEmail.CreateMailMessage("Secret found !", "We found the secret message in your documents, please see the attached report.");
                bLEmail.AddAttachment(mailMessage, new Attachment(stream, new ContentType("application / pdf")));

                string userEmail = DAO.GetInstance().GetUserByLogin(userLogin).Email;
                if (!bLEmail.SendEmail(userEmail, mailMessage))
                {
                    return new Message
                    {
                        info = "Could not send an email to the following address : " + userEmail,
                        operationStatus = false
                    };
                }
            }

            return new Message
            {
                operationStatus = true,
                data = response
            };
        }
    }
}
