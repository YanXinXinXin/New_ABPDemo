using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Acme.BookStore.Authors;
using Acme.BookStore.EntityFrameworkCore;

namespace Acme.BookStore.Web.Views.Home
{
    public class Test2Model : PageModel
    {
        private readonly Acme.BookStore.EntityFrameworkCore.BookStoreDbContext _context;

        public Test2Model(Acme.BookStore.EntityFrameworkCore.BookStoreDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
