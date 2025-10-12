using LTWDay06Lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTWDay06Lab.Controllers
{
    public class UserController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManual()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserManual(User user)
        {
            string password = user.Password;
            if(password.Length < 7)
            {
                ViewBag.PasswordErr = "Mật khẩu có độ dài tối thiểu 7 kí tự";
                return View();
            }
            
            string email = user.Email;
            string regexPattern = @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, regexPattern))
            {
                ViewBag.EmailErr = "Email không đúng định dạng";
                return View();
            }
            return Content("Bạn đã qua!");
        }
    }
}
