using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Specifications;

namespace Acme.BookStore.Books
{
    public class Donot99PriceBookSpecification : Specification<Book>
    {
        public override Expression<Func<Book, bool>> ToExpression()
        {
            return s => s.Price >= 99;
        }
    }
}
