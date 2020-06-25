using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BLDecrypt
    {
        public string Secret { get; private set; }
        public string Key { get; private set; }
        public string DocumentName { get; private set; }
        public IDictionary<string, string> Documents { get; private set; }

        private int CPuCoreCount
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DecypherDocument(string documentName, string key)
        {
            throw new NotImplementedException();
        }

        public string YieldNextKey()
        {
            throw new NotImplementedException();
        }
    }
}
