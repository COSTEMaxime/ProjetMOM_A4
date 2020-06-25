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
        private string url;
        private string action;

        private HttpWebRequest webRequest;
        private XmlDocument soapEnvelopeXml;

        internal BLJEEMessage(string url, string action)
        {
            this.url = url;
            this.action = action;
        }

        internal void PrepareAndSendMessage(Message message, AsyncCallback callback = null)
        {
            CreateWebRequest();
            CreateSoapEnvelope(Deserialize(message));
            InsertSoapEnvelopeIntoWebRequest();
            webRequest.BeginGetResponse(callback, null);
        }

        private void CreateWebRequest()
        {
            webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
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

        private string Deserialize(Message message)
        {
            return new JavaScriptSerializer().Serialize(message);
        }

        private void InsertSoapEnvelopeIntoWebRequest()
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
