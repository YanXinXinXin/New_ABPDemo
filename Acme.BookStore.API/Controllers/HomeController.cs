using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.BookStore.API.Controllers
{
    public class HomeController : Controller
    { 
      [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
       [HttpGet]
        public IActionResult Index2()0
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }
    }
}
