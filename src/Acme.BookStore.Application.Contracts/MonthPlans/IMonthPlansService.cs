
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.MonthPlans
{
    public interface IMonthPlansService:IApplicationService
    {
         Task<MonthPlanDto> CreateMonPlan( CreateMonthPlanDto data);

        Task<PagedResultDto< MonthPlanDto>> GetListAsync(GetMonthPlansListDto data);
    }
}
