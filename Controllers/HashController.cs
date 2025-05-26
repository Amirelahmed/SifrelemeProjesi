using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SifrelemeProjesi.Controllers
{
    public class HashController : Controller
    {
        //Sha256----------------------------------------------
        [HttpGet]
        public IActionResult Sha256()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sha256(string input)
        {
            using var sha = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha.ComputeHash(bytes);
            ViewBag.HashResult = BitConverter.ToString(hash).Replace("-", "").ToLower();
            ViewBag.InputText = input;
            return View();
        }
        //----------------------------------------------------
    }
}
