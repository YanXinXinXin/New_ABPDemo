using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.User
{
     public class StaffUser: FullAuditedAggregateRoot<Guid>
    {
        public string  UserName { get;  set; }

        public string  GangWei { get; set; }
        /// <summary>
        /// 上级主管
        /// </summary>
        public string Supervisor { get; set; }
        private StaffUser()
        {

        }
        internal StaffUser(Guid id, [NotNull] string userName, [NotNull] string ganWei, [NotNull] string supervisor)
            : base(id)
        {
            UserName = userName; GangWei = ganWei; Supervisor = supervisor;
        }
    }
}
