using JobSearchApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using JobSearchApplication.Services;

namespace JobSearchApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobappdbContext dbcontext;
        public HomeController(JobappdbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        JobappdbContext db = new JobappdbContext();

        public IActionResult Index()
        {
            HttpContext.Session.SetString("UserSession", "User");
            TempData["SessionID"] = HttpContext.Session.Id;

            return View();
        }
        public IActionResult About()
        {
           if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.Data = HttpContext.Session.GetString("UserSession").ToString();
            }
            return View();
        }
       

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
