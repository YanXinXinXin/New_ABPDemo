using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Acme.BookStore.User
{
    public class EfCoreStaffUserRepository :EfCoreRepository<BookStoreDbContext, StaffUser, Guid>, IStaffUserRepository
    {
        public EfCoreStaffUserRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider):base(dbContextProvider)
        {

        }

        public async Task<StaffUser> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(s => s.UserName == name);
        }
    }
}
