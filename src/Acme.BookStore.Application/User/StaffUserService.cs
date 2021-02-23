using Acme.BookStore.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.User
{
    public class StaffUserService: ApplicationService, IStaffUserService
    {
        private readonly StaffUserManger _staffUserManger;
        private readonly IStaffUserRepository _staffUserRepository;

        public StaffUserService(IStaffUserRepository staffUserRepository,
            StaffUserManger staffUserManger
            )
        {
            _staffUserManger = staffUserManger;
            _staffUserRepository = staffUserRepository;
        }

        public async Task<StaffUserDto> CreateUser(CreateStaffUserDto staffUser)
        {
           var staffuser= await _staffUserManger.CreateAsyne(staffUser.UserName, staffUser.GanWei, staffUser.Supervisor);
            await _staffUserRepository.InsertAsync(staffuser);
            return ObjectMapper.Map<StaffUser, StaffUserDto>(staffuser);
        }
    }
}
