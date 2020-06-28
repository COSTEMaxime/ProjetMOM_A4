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
        readonly JavaEEService.CheckerEndpointClient client;

        internal BLJEEMessage()
        {
            client = new JavaEEService.CheckerEndpointClient();
        }

        internal async Task<JavaEEService.checkOperationResponse1> SendMessageAsync(JavaEEService.msg message)
        {
            return await client.checkOperationAsync(message);
        }

        internal bool SendMessage(JavaEEService.msg message)
        {
            return client.checkOperation(message);
        }
    }
}
