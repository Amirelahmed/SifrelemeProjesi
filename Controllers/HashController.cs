using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SifrelemeProjesi.Controllers
{
    public class HashController : Controller
    {
        [HttpGet]
        public IActionResult Sha256()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sha256(string input, IFormFile file)
        {
            string hashResult = null;
            bool isFileMode = false;

            if (!string.IsNullOrEmpty(input))
            {
                using var sha = SHA256.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(bytes);
                hashResult = BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
            else if (file != null && file.Length > 0)
            {
                using var sha = SHA256.Create();
                using var stream = file.OpenReadStream();
                byte[] hash = sha.ComputeHash(stream);
                hashResult = BitConverter.ToString(hash).Replace("-", "").ToLower();
                isFileMode = true;
            }

            ViewBag.HashResult = hashResult;
            ViewBag.InputText = input;
            ViewBag.IsFileMode = isFileMode;
            ViewBag.ShowHash = hashResult != null;

            return View();
        }
    }
}
