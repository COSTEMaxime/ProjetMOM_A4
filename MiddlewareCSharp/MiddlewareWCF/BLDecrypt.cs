using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MiddlewareWCF
{
    class BLDecrypt
    {
        public string Document { get; private set; }
        public string DocumentName { get; private set; }

        private static readonly char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static int MaxKey
        {
            get
            {
                return MinKey + (int)Math.Pow(alphabet.Length, 4);
            }
        }

        public static int MinKey
        {
            get
            {
                // skip keys of length 3,2 and 1
                return (int)Math.Pow(alphabet.Length, 3) + (int)Math.Pow(alphabet.Length, 2) + (int)Math.Pow(alphabet.Length, 1);
            }
        }

        public BLDecrypt(string documentName, string document)
        {
            Document = document;
            DocumentName = documentName;
        }

        public string DecypherDocument(string key)
        {
            StringBuilder result = new StringBuilder();

            for (int c = 0; c < Document.Length; c++)
            {
                result.Append((char)(Document[c] ^ key[c % key.Length]));
            }

            return result.ToString();
        }

        public static string GetKey(int i)
        {
            return i < 0 ? "" : GetKey((i / alphabet.Length) - 1) + alphabet[i % 26];
        }
    }
}
