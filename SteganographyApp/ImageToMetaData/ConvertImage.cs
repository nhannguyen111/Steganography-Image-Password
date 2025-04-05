using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace SteganographyApp.ImageToMetaData
{
/// <summary>
/// The purpose of this class is to convert different image types to metadata such as png, jpg, etc.
/// from the metadata it will be sent for processing
/// </summary>
    public class ConvertImage
    {
        public string DataDump(string imagePath) 
        {
            string metaData = "";
            byte[] bytes = File.ReadAllBytes(imagePath);

            // Convert bytes to text
            string rawContent = Encoding.GetEncoding("ISO-8859-1").GetString(bytes);

            // Split into lines (handling both \r\n and \n)
            string[] lines = rawContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Take the first 100 lines (or all if fewer than 100)
            var first200Lines = lines.Take(10);

            // Print each line
            foreach (string line in first200Lines)
            {
                //Debug.WriteLine(line);
                metaData = metaData + line + "\n";

            }

            return metaData;
        }
    }
    
}
