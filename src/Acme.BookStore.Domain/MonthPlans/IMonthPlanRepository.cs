using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.MonthPlans
{
    public interface IMonthPlanRepository:IRepository<MonthlPlan, Guid>
    {
        Task<List<MonthlPlan>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting
            );
    }
}
