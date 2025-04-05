using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyApp.Parser
{
    internal class Parser
    {
        static string Encoding(string data)
        {
            string readableData = "";

            string metadata = new string(data.Where(c => !char.IsWhiteSpace(c)).ToArray());

            foreach (char c in metadata)
            {
                readableData += GetPrintableAscii(c);
            }

            return readableData;
        }

        static char GetPrintableAscii(int n)
        {
            int start = 33;
            int total = 122;
            int asciiValue = start + (n % total);
            return (char)asciiValue;
        }
    }
}
