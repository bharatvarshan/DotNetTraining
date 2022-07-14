using FormApplicationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        
    }
}