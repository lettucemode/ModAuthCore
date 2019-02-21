using FirstADWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FirstADWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var cp = this.User;
            var welcome = $"Welcome, {cp.FindFirst(ClaimTypes.GivenName).Value} {cp.FindFirst(ClaimTypes.Surname).Value}";
            return View();
        }

        public IActionResult About()
        {
            var str = string.Empty;
            var cp = this.User;
            foreach (var c in cp.Claims)
            {
                str += $"{c.Type} : {c.Value}\n";
            }
            ViewData["Message"] = str;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
