//using System;
//using System.Text;

//namespace SteganographyApp.KeyGenerators
//{
//    public class KeyGeneratorPassword
//    {
//        // a fixed mask—keep it secret in your code
//        private const int Mask = unchecked((int)0xA5A5A5A5);

//        /// <summary>
//        /// Generates an obfuscated key from a randomly generated password slice.
//        /// </summary>
//        /// <param name="data">The source string (e.g. your hashed metadata).</param>
//        /// <param name="passwordLength">How many chars you want in the password.</param>
//        /// <returns>
//        /// A Base64 string that encodes (startIndex ^ Mask) and (endIndex ^ Mask).
//        /// </returns>
//        public string GenerateKey(string hashedMetaData, int passwordLength)
//        {
//            // 1) Generate the password and record start/end in PasswordCreator
//            //var passwordData = new PasswordCreator();
//            //string pwd = passwordData.getPassword(hashedMetaData, passwordLength);

//            //// 2) Grab the real indices
//            //int start = passwordData.startIndex;
//            //int end = passwordData.endIndex;
//            // (If your endIndex isn't set in getPassword, do: end = start + pwd.Length - 1;)

//            // 3) Obfuscate via XOR
//            int obfStart = start ^ Mask;
//            int obfEnd = end ^ Mask;

//            // 4) Pack into bytes and Base64‑encode
//            byte[] buf = new byte[8];
//            BitConverter.GetBytes(obfStart).CopyTo(buf, 0);
//            BitConverter.GetBytes(obfEnd).CopyTo(buf, 4);
//            return Convert.ToBase64String(buf);
//        }

//        /// <summary>
//        /// Re‑extracts the password given the obfuscated key.
//        /// </summary>
//        public string RegeneratePassword(string hashedMetaData, string key)
//        {
//            // 1) Decode Base64
//            byte[] buf = Convert.FromBase64String(key);
//            if (buf.Length != 8)
//                throw new ArgumentException("Invalid key length", nameof(key));

//            // 2) Unpack and un‑XOR
//            int obfStart = BitConverter.ToInt32(buf, 0);
//            int obfEnd = BitConverter.ToInt32(buf, 4);
//            int start = obfStart ^ Mask;
//            int end = obfEnd ^ Mask;

//            // 3) Slice back out
//            int length = end - start + 1;
//            if (start < 0 || length <= 0 || start + length > hashedMetaData.Length)
//                throw new ArgumentOutOfRangeException("Key out of bounds");

//            return hashedMetaData.Substring(start, length);
//        }
//    }
//}

