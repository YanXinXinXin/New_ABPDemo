using Acme.BookStore.Authors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plan.Form.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Plan.Form.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IAuthorAppService _authorAppService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger
            ,IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index(GetAuthorListDto input)
        {
             await  _authorAppService.GetListAuthorAsync(input);
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
