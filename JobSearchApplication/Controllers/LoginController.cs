using JobSearchApplication.Models;
using JobSearchApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly JobappdbContext context;

        public LoginController(JobappdbContext context)
        {
            this.context = context;
        }

        JobappdbContext db = new JobappdbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserCredential user)
        {
            var myUser = context.UserCredentials.FirstOrDefault(x => x.Email == user.Email);
            if (myUser != null)
            {
                var decryptedPassword = EncryptionHelper.Decrypt(myUser.Password);
                if (decryptedPassword == user.Password)
                {
                    HttpContext.Session.SetString("UserSession", user.Email);
                    return RedirectToAction("Dashboard");
                }
            }
            ViewBag.Message = "Login Failed";
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(UserCredential user)
        {
            if (ModelState.IsValid == true)
            {
                var roleid = db.Roles.FirstOrDefault(r => r.Name == user.Role.ToString())?.RoleId;
                user.Password = EncryptionHelper.Encrypt(user.Password);

                db.UserCredentials.Add(user);
                int row = db.SaveChanges();
                if (row > 0)
                {
                    TempData["Success"] = "Registration Successfull";
                    ModelState.Clear();
                }

            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Home");
            }
            return View();
        }
    }

}
