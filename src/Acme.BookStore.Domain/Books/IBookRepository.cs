using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Books
{
    public  interface IBookRepository:IRepository<Book,Guid>
    {
       /// <summary>
       /// 根据名字查找
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
        Task<Book> FindByNameAsync(string name);
        
               

    }
}
