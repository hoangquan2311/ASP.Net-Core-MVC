using DaiLyOTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaiLyOTO.Controllers
{
    public class AccessController : Controller
    {
        QlotoContext db = new QlotoContext();

        [HttpGet]
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return View();
            }
            else if (HttpContext.Session.GetString("Email") == "admin")
            {
                return RedirectToAction("index", "admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // login vào hệ thống
        [HttpPost]
        public IActionResult Login(TaiKhoanNv user)
        {
            var obj = db.TaiKhoanNvs.FirstOrDefault(x => x.Email == user.Email && x.MatKhau == user.MatKhau);
            if (obj != null)
            {
                HttpContext.Session.SetString("Email", obj.Email.ToString());
                HttpContext.Session.SetString("IdtaiKhoan", obj.IdtaiKhoan.ToString());
                return RedirectToAction("index", "admin");
            }

            // Trả về trang Login với thông báo lỗi tương ứng
            return View();
            //return RedirectToAction("Index", "Home");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("IdtaiKhoan");
            return RedirectToAction("Login", "Access");
        }
        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgortPassword()
        {
            return View();
        }

    }
}
