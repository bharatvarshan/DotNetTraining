using Microsoft.AspNetCore.Mvc;

namespace MVCFirstApp.Controllers
{
    [Route("bharat")]
    public class EmployeeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("add-employee")]

        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}
