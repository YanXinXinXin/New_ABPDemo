using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Authors;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Web.Pages.Authors
{
    public class DefaultModel : PageModel
    {
        private readonly IAuthorAppService _authorAppService;

        public DefaultModel(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }
        public PagedResultDto<AuthorDto> Author { get; private set; }
        //  public    <AuthorDto> Author { get; private set; }
        public async Task OnGet(GetAuthorListDto input)
        {
            //Author = await _authorAppService.GetListAuthorAsync(input);
            Author = await _authorAppService.GetListAsync(input);
            //var data = "b8f5c1a9-e910-fb6c-5f10-39fa16dd492c";
            //Author=await _authorAppService.GetAsync(Guid.Parse(data));
        }
    
    }
}
