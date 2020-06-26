using ContractWCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MiddlewareWCF
{
    class BLJEEMessage
    {
        private readonly string url;
        private readonly string action;

        public HttpWebRequest WebRequest { get; private set; }
        private XmlDocument soapEnvelopeXml;

        internal BLJEEMessage(string url, string action)
        {
            this.url = url;
            this.action = action;
        }

        internal void PrepareAndSendMessage(Message message, AsyncCallback callback = null)
        {
            CreateWebRequest();;
            CreateSoapEnvelope(Serialize(message));
            InsertSoapEnvelopeIntoWebRequest();
            WebRequest.BeginGetResponse(callback, null);
        }

        private void CreateWebRequest()
        {
            WebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            WebRequest.Headers.Add("SOAPAction", action);
            WebRequest.ContentType = "text/xml;charset=\"utf-8\"";
            WebRequest.Accept = "text/xml";
            WebRequest.Method = "POST";
            WebRequest.Proxy = null;
        }

        private void CreateSoapEnvelope(string xml)
        {
            soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(xml);
        }


        private string Serialize(object object_)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream, object_);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }

        public T Deserialize<T>(string xmlString)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                SoapFormatter formatter = new SoapFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }

        private void InsertSoapEnvelopeIntoWebRequest()
        {
            using (Stream stream = WebRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
