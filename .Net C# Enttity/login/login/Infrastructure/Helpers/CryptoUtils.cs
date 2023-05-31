using System.Security.Cryptography;
using System.Text;

namespace login.Infrastructure.Helpers
{
    public class CryptoUtils
    {
        public string Encrypt(string plainText, string passphrase)
        {
            byte[] key = new byte[]
            {
                0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
                0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
                0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
                0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
            };

            byte[] iv = new byte[]
            {
                0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27,
                0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            };

            byte[] clearData = Encoding.UTF8.GetBytes(plainText);

            using (Aes alg = Aes.Create())
            {
                alg.Key = key;
                alg.IV = iv;

                using (var ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(clearData, 0, clearData.Length);
                    cs.Close();
                    byte[] encryptedData = ms.ToArray();
                    return BitConverter.ToString(encryptedData).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
