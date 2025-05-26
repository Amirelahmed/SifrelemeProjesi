using System.Security.Cryptography;
using System.Text;

namespace SifrelemeProjesi.Models
{
    public class RsaService
    {
        public RSAParameters PublicKey;
        public RSAParameters PrivateKey;

        //GenerateKeys----------------------------------------
        public void GenerateKeys()
        {
            using (var rsa = RSA.Create(2048))
            {
                PublicKey = rsa.ExportParameters(false);
                PrivateKey = rsa.ExportParameters(true);
            }
        }
        //-----------------------------------------------------

        //Encrypt----------------------------------------------
        public string Encrypt(string plainText)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(PublicKey);
                var data = Encoding.UTF8.GetBytes(plainText);
                var encrypted = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(encrypted);
            }
        }
        //-----------------------------------------------------

        //Decrypt----------------------------------------------
        public string Decrypt(string cipherText)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportParameters(PrivateKey);
                var data = Convert.FromBase64String(cipherText);
                var decrypted = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
        //-----------------------------------------------------
    }
}
