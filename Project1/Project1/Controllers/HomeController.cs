using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var listName = new NameViewModel
            {
                Names = new List<string> { "Ali", "Khaled", "Jim" },
                Ages = new List<int> { 30, 35, 21 }
            };
            ViewBag.Name = "Me";
            ViewBag.Val = 123.65;
            return View(listName);
        }
 
        public IActionResult Test()
        {
            var names = new List<string> { "Ali","Khaled","Jim"};

            return View(names);
        }

        [HttpGet]
        public IActionResult Calc()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Calc(FutureValue model)
        {
            ViewBag.Result = model.CalculateFutureValue();
            return View(model);
        }

        public IActionResult Me()
        {
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
