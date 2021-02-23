using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.User
{
    public interface IStaffUserRepository :IRepository<StaffUser, Guid>
    {
        Task<StaffUser> FindByNameAsync(string name);
    }
}
