using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyApp
{
    public static class Parser
    {
        public static string GetReadableData(string data)
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
            int start = 32;
            int total = 95;
            int asciiValue = start + (n % total);
            return (char)asciiValue;
        }
    }
}
