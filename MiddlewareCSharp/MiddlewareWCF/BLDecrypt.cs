using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

        private static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static int alphabetLengthPow2 = alphabet.Length * alphabet.Length;
        private static int alphabetLengthPow3 = alphabetLengthPow2 * alphabet.Length;
        private static int alphabetLengthPow4 = alphabetLengthPow3 * alphabet.Length;
        private int count = -1;

        private int CPuCoreCount
        {
            get
            {
                return Environment.ProcessorCount;
            }
        }

        public string DecypherDocument(string documentName, string key)
        {
            StringBuilder result = new StringBuilder();
            string text = Documents[documentName];

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }

        string GetNextKey()
        {
            count++;
            return new string(new char[] {
                alphabet[count / BLDecrypt.alphabetLengthPow4],
                alphabet[count / BLDecrypt.alphabetLengthPow3],
                alphabet[count / BLDecrypt.alphabetLengthPow2],
                alphabet[count % 26]
            });
        }
    }
}
