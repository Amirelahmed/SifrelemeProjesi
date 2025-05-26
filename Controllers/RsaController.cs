using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SifrelemeProjesi.Controllers
{
    public class RsaController : Controller
    {
        private static string publicKeyText;
        private static string privateKeyText;

        //Encrypt-----------------------------------------------
        [HttpGet]
        public IActionResult Encrypt()
        {
            ViewBag.PublicKey = publicKeyText;
            ViewBag.PrivateKey = privateKeyText;
            return View();
        }

        [HttpPost]
        public IActionResult Encrypt(string plainText, string publicKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(publicKey.ToCharArray());
                    var data = Encoding.UTF8.GetBytes(plainText);
                    var encrypted = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                    ViewBag.EncryptedText = Convert.ToBase64String(encrypted);
                }
            }
            catch (Exception ex)
            {
                ViewBag.EncryptedText = "Hata: " + ex.Message;
            }

            ViewBag.InputPlainText = plainText;
            ViewBag.PublicKey = publicKeyText;
            ViewBag.PrivateKey = privateKeyText;
            return View();
        }
        //------------------------------------------------------

        //Decrypt-----------------------------------------------
        [HttpGet]
        public IActionResult Decrypt()
        {
            ViewBag.PublicKey = publicKeyText;
            ViewBag.PrivateKey = privateKeyText;
            return View();
        }

        [HttpPost]
        public IActionResult Decrypt(string encryptedText, string privateKey)
        {
            try
            {
                using (var rsa = RSA.Create())
                {
                    rsa.ImportFromPem(privateKey.ToCharArray());
                    var data = Convert.FromBase64String(encryptedText);
                    var decrypted = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
                    ViewBag.DecryptedText = Encoding.UTF8.GetString(decrypted);
                }
            }
            catch (Exception ex)
            {
                ViewBag.DecryptedText = "Hata: " + ex.Message;
            }

            ViewBag.InputEncryptedText = encryptedText;
            ViewBag.PublicKey = publicKeyText;
            ViewBag.PrivateKey = privateKeyText;
            return View();
        }
        //------------------------------------------------------

        //GenerateKeys------------------------------------------
        [HttpPost]
        public IActionResult GenerateKeys()
        {
            using (var rsa = RSA.Create(2048))
            {
                var privateKeyBytes = rsa.ExportPkcs8PrivateKey();
                var publicKeyBytes = rsa.ExportSubjectPublicKeyInfo();

                privateKeyText = ExportPrivateKeyToPem(privateKeyBytes);
                publicKeyText = ExportPublicKeyToPem(publicKeyBytes);
            }

            return RedirectToAction("Encrypt");
        }
        //------------------------------------------------------

        //ExportPrivateKeyToPem---------------------------------
        private string ExportPrivateKeyToPem(byte[] privateKeyBytes)
        {
            var builder = new StringBuilder();
            builder.AppendLine("-----BEGIN PRIVATE KEY-----");
            builder.AppendLine(Convert.ToBase64String(privateKeyBytes, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END PRIVATE KEY-----");
            return builder.ToString();
        }
        //------------------------------------------------------

        //ExportPublicKeyToPem----------------------------------
        private string ExportPublicKeyToPem(byte[] publicKeyBytes)
        {
            var builder = new StringBuilder();
            builder.AppendLine("-----BEGIN PUBLIC KEY-----");
            builder.AppendLine(Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END PUBLIC KEY-----");
            return builder.ToString();
        }
        //------------------------------------------------------
    }
}
