using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyApp
{
    public class PasswordCreator
    {
        public int getRandomLocation(int fileLength, int passwordSize)
        {
            Random random = new Random();
            return random.Next(0, fileLength - passwordSize);
        }

        public string getPassword(string data, int passwordLength)
        {
            int startIndex = getRandomLocation(0, data.Length);

            string currPassword = "";

            while (currPassword.Length < passwordLength)
            {
                currPassword += data[startIndex];
                startIndex++;
            }

            // If not valid password
            //getPassword(data, passwordLength);

            return currPassword;
        }
    }
}
