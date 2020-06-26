using ContractWCF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;

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
            CreateWebRequest();
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
        }

        private void CreateSoapEnvelope(string deserializedMessage)
        {
            soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(
                @"<?xml version=""1.0"" encoding=""UTF-8""?><S:Envelope xmlns:S=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"">
                <SOAP-ENV:Header />
                    <S:Body xmlns:ns2=""http://facade.messagemgmt.checker.com/"">
                        <ns2:checkOperation>
                            <message>" + deserializedMessage + @"</message>
                        </ns2:checkOperation>
                    </S:Body>
                </S:Envelope>");
        }

        private string Serialize(Message message)
        {
            return new JavaScriptSerializer().Serialize(message);
        }

        public T Deserialize<T>(string json)
        {
            return new JavaScriptSerializer().Deserialize<T>(json);
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
