using System.IO;
using System.IO.Compression;
using System.Text;

namespace System
{
    public static class StringExtension
    {
        public static byte[] Base64UrlDecodeToBytes(this string value)
        {
            string incoming = value
                .Replace('_', '/')
                .Replace('-', '+');

            switch (value.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }

            return Convert.FromBase64String(incoming);
        }

        public static string DecompressDeflateBase64UrlString(this string input, Encoding encoding = default(Encoding))
        {
            encoding = encoding ?? Encoding.UTF8;

            var inputBytes = Base64UrlDecodeToBytes(input);

            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(inputBytes))
                using (var decompressionStream = new DeflateStream(inputStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(outputStream);
                }

                var outputBytes = outputStream.ToArray();
                return encoding.GetString(outputBytes);
            }
        }

        public static string Base64UrlDecode(this string value, Encoding encoding = default(Encoding))
        {
            encoding = encoding ?? Encoding.UTF8;

            byte[] bytes = Base64UrlDecodeToBytes(value);
            return encoding.GetString(bytes);
        }
    }
}
