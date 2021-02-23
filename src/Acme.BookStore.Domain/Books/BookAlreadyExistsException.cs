using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Acme.BookStore.Books
{
    public class BookAlreadyExistsException : BusinessException
    {
        public BookAlreadyExistsException(string name)
            :base(BookStoreDomainErrorCodes.BookAlreadyExists)
        {
            WithData("name",name);
        }
    }
}
