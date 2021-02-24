using Acme.BookStore.Authors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Acme.BookStore.Web.Pages.Authors.CreateModalModel;

namespace Acme.BookStore.Web.Controllers
{
    //[ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IAuthorAppService _authorAppService;

        public HomeController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(GetAuthorListDto input)
        {
            //        < script src = "../Pages/Users/jquery.js" ></ script >

            // < script >
            //     function BtnChaXun() {
            //            console.log($('.WorkPlanTransfer').val());
            //        $.ajax({
            //            type: 'post',
            //            url: '/Home/Default2',
            //            data:
            //                {
            //                name: $('.WorkPlanTransfer').val()
            //            } ,
            //        }).done(() => {
            //                alert("添加成功");

            //            })
            //         .fail(() => {

            //             console.log("失败了");
            //         });
            //        }

            //</ script >


            return View(await _authorAppService.GetListAuthorAsync(input));
        }
        [HttpPost]
        public async Task<IActionResult> Index(string name)
        {

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Default() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Default(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                var data = model;
            }

            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Default2(string name)
        {

            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Default(AuthorDto author)
        //{
        //    ViewBag.data = author.Name;

        //    return View();
        //}

        //[HttpGet("{id}")]
        //public async  Task<ActionResult<AuthorDto>> AuthorDetails(Guid id)
        //{
        //    var data = await _authorAppService.GetAsync(id);
        //    if (data==null)
        //    {
        //        return NoContent();
        //    }
        //    return data;
        //    //Author = new CreateAuthorViewModel();
        //    // return NoContent();
        //   // return  new {resule=123,data=4456});
        //}

        [HttpGet]
        public async Task<ActionResult<AuthorDto>> AuthorDetails(Guid id)
        {
            var data = await _authorAppService.GetAsync(id);
            if (data == null)
            {
                return NoContent();
            }

            return View();
            //Author = new CreateAuthorViewModel();
            // return NoContent();
            // return  new {resule=123,data=4456});
        }

        [HttpGet]
        public List<AuthorDto> Test() {
            var rng = new Random();
            return Enumerable.Range(1, 5)
                .Select(s => new AuthorDto
                {
                    Id = Guid.NewGuid(), Name = "画画", BirthDate = DateTime.Now.AddDays(1),
                    ShortBio = "132"

                }).ToList();
        }

        [HttpGet]
        public IActionResult Test2()
        {

            return View("Test2");
        }
        public class StudentModel{
            [Required]
            public string StudentName { get; set; }

        }
    }
}
