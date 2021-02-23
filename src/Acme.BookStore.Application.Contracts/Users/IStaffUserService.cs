using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Users
{
    public interface IStaffUserService:IApplicationService
    {
        Task<StaffUserDto> CreateUser(CreateStaffUserDto staffUser);
    }
}
