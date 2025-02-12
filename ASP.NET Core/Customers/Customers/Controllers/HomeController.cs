using System.Diagnostics;
using Customers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    public class HomeController : Controller
    {
        // This is being fired on start up displaying the index page
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult CustomerForm()
        {
            return View();
        }
    }
}
