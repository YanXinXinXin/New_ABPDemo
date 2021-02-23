using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.User
{
    public class StaffUserManger: DomainService
    {
        private readonly IStaffUserRepository _staffUserRepository;

        public StaffUserManger(IStaffUserRepository staffUserRepository)
        {
            _staffUserRepository = staffUserRepository;
        }
        public async Task<StaffUser> CreateAsyne([NotNull] string userName, [NotNull] string ganWei, [NotNull] string supervisor)
        {
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            var data= await _staffUserRepository.FindByNameAsync(userName);
            if (data!=null)
            {
                throw new ArgumentException(userName);
            }
            return new StaffUser(GuidGenerator.Create(), userName, ganWei, supervisor);
        }
    }
}
