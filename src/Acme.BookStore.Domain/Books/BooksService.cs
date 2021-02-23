using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.BookStore.Books
{
    public   class BooksService: ITransientDependency
    {
        public  void  BookPrice(Book book)
        {
            if ( !new Donot99PriceBookSpecification().IsSatisfiedBy(book))
            {
                throw new Exception(
                    "钱多了"
                );
            }

            //TODO...
        }
    }
}
