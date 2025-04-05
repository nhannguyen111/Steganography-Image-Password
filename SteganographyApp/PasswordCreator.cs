using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyApp
{
    public static class PasswordCreator
    {
        public  static int getRandomLocation(int fileLength, int passwordSize)
        {
            Random random = new Random();
            return random.Next(0, fileLength - passwordSize);
        }

        public static string getPassword(string metaData, int passwordLength)
        {
            string data = Parser.GetReadableData(metaData);

            int startIndex = getRandomLocation(data.Length, passwordLength);
            int pointer = startIndex;
            string currPassword = "";
            char lastChar = ' ';

            while (currPassword.Length < passwordLength && pointer < data.Length)
            {
                if (lastChar != data[pointer] && data[pointer] != ' ')
                {
                    currPassword += data[pointer];
                    lastChar = metaData[pointer];
                }
                pointer++;
            }

            // If not valid password
            if (currPassword.Length < passwordLength)
            {
                getPassword(data, passwordLength);
            }

            // Normalize password
            return PasswordValidator.CreateValidPassword(currPassword, passwordLength);

            return currPassword;
        }

        public static string getKey(string metaData, int passwordLength)
        {
            string data = Parser.GetReadableData(metaData);

            int startIndex = getRandomLocation(data.Length, passwordLength);
            int pointer = startIndex;
            string currPassword = "";
            char lastChar = ' ';

            while (currPassword.Length < passwordLength && pointer < data.Length)
            {
                if (lastChar != data[pointer] && data[pointer] != ' ')
                {
                    currPassword += data[pointer];
                    lastChar = metaData[pointer];
                }
                pointer++;
            }

            // If not valid password
            if (currPassword.Length < passwordLength)
            {
                getPassword(data, passwordLength);
            }

            // Normalize password
            return $"{startIndex}-{passwordLength}";


            //return currPassword;
        }

        public static string getPasswordFromKey(string metaData, string key)
        {
            string data = Parser.GetReadableData(metaData);

            string keyparse = key;
            string keyStart = "";
            string keyLength = "";
            bool swap = false;

            foreach (char c in keyparse)
            {
                if (c == '-') { 
                    swap = true;
                }
                else if (!swap && char.IsDigit(c))
                {
                    keyStart += c;
                }
                else if (swap && char.IsDigit(c))
                {
                    keyLength += c;
                }
            }

            int start = int.Parse(keyStart);
            int length = int.Parse(keyLength);

            int startIndex = start;
            int pointer = startIndex;
            string currPassword = "";
            char lastChar = ' ';

            while (currPassword.Length < length && pointer < data.Length)
            {
                if (lastChar != data[pointer] && data[pointer] != ' ')
                {
                    currPassword += data[pointer];
                    lastChar = metaData[pointer];
                }
                pointer++;
            }


            // Normalize password


            return currPassword;
        }
    }
}
