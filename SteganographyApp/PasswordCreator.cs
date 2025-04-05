using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyApp
{
    public class PasswordCreator
    {
        public int startIndex = 0;
        public int endIndex = 0;
        public int getRandomLocation(int fileLength, int passwordSize)
        {
            Random random = new Random();
            return random.Next(0, fileLength - passwordSize);
        }


        public string getPassword(string data, int passwordLength)
        {
            this.startIndex = getRandomLocation(0, data.Length);
            this.endIndex = passwordLength;
            int pointer = startIndex;
            string currPassword = "";

            while (currPassword.Length < passwordLength && startIndex < data.Length)
            {
                currPassword += data[startIndex];
                pointer++;
            }

            // If not valid password
            if (currPassword.Length < passwordLength)
            {
                getPassword(data, passwordLength);
            }

            // Normalize password

            return currPassword;
        }
    }
}
