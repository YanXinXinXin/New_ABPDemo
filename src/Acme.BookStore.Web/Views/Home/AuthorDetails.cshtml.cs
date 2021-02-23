using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Authors;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Views.Home
{
    public class AuthorDetailsModel : AbpPageModel
    {
        private readonly IAuthorAppService _authorAppService;

        [BindProperty]
        public CreateAuthorViewModel Author  { get; set; }
        public AuthorDetailsModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task<List<CreateAuthorViewModel>> OnGetAsync(GetAuthorListDto input)
        {
           var data= await _authorAppService.GetListAuthorAsync(input);
          return ObjectMapper.Map<List<AuthorDto>, List<CreateAuthorViewModel>>(data);
            //Author = new CreateAuthorViewModel();
        }
        public void OnGet() { 
        
        }
        public class CreateAuthorViewModel
        {
            [Required]
            [StringLength(AuthorConsts.MaxNameLength)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            [TextArea]
            public string ShortBio { get; set; }

        }
    }
}
