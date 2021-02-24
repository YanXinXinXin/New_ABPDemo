using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Users;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Modularity;

namespace Acme.BookStore.Web.Pages.Users
{
    public class CreateModelModel :AbpPageModel
    {
        private readonly IStaffUserService _staffUserService;

       
        public CreateModelModel(IStaffUserService staffUserService)
        {
            _staffUserService = staffUserService;
        }
        [BindProperty]
        public CreateStaffUserViewModel StaffUser { get; set; }
        public void OnGet()
        {
            StaffUser = new CreateStaffUserViewModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var User = ObjectMapper.Map<CreateStaffUserViewModel, CreateStaffUserDto>(StaffUser);
                await _staffUserService.CreateUser(User);
                
            }
            return NoContent();

        }
        public class CreateStaffUserViewModel
        {
            [Required]
            [DisplayName("姓名")]
            public string UserName { get; set; }
            [Required]
            [Display(Name ="岗位")]
            public string GanWei { get; set; }
            [Required]
             [Display(Name ="上级主管")]
            public string Supervisor { get; set; }
        }

     }
}

