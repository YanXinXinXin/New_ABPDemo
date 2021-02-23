using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Acme.BookStore.Authors;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages
{
    public class Test2Model : AbpPageModel
    {
        private readonly IAuthorAppService _authorAppService;

        public Test2Model(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public IActionResult OnGet()
        {
            Author = new CreateAuthorViewModel();
            return Page();
        }

        [BindProperty]
        public CreateAuthorViewModel Author { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //_context.Authors.Add(Au thor);
            //await _context.SaveChangesAsync();
             var dto = ObjectMapper.Map<CreateAuthorViewModel, CreateAuthorDto>(Author);
            await _authorAppService.CreateAsync(dto);
           
            return RedirectToPage("Index");
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
