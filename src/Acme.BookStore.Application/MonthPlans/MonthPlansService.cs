
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.MonthPlans
{
    public class MonthPlansService : ApplicationService, IMonthPlansService
    {
        private readonly IMonthPlanRepository _monthPlanRepository;
        private readonly MonthPlanManger _monthPlanManger;

        public MonthPlansService(IMonthPlanRepository monthPlanRepository,
            MonthPlanManger monthPlanManger)
        {
            _monthPlanRepository = monthPlanRepository;
              _monthPlanManger = monthPlanManger;
        }
        public async Task<MonthPlanDto> CreateMonPlan(CreateMonthPlanDto data)
        {
           
            var MonthlPlan = _monthPlanManger.CreateAsync(data.WorkPlanContent, data.WorkPlanTransfer, data.ProposedCompletionTime, data.TaskScore,
                data.ProposedGoal, data.Year, data.Month, data.Day,data.ActualCompletion,data.TaskCompletionRate
                ,data.ActualCompletionTime,data.SelfRating,data.AchievementOfSuperiorReviewGoals,data.SuperiorScore);
            MonthlPlan.StaffUserId = Guid.Parse("405e0d17-de0f-bb49-25e3-39fa917cc375");
            await _monthPlanRepository.InsertAsync(MonthlPlan);
            return ObjectMapper.Map<MonthlPlan, MonthPlanDto>(MonthlPlan);
        }

        public async Task<PagedResultDto<MonthPlanDto>> GetListAsync(GetMonthPlansListDto data)
        {
            if (data.Sorting.IsNullOrWhiteSpace())
            {
                 data.Sorting = nameof(MonthlPlan.WorkPlanContent);
            }
            var monthplans =await  _monthPlanRepository.GetListAsync(
                 data.SkipCount,
                 data.MaxResultCount,
                 data.Sorting
                );

            // var monthplans= await _monthPlanRepository.GetListAsync();
             var Count = await _monthPlanRepository.GetCountAsync();
            //var test = ObjectMapper.Map<MonthlPlan, MonthPlanDto>(monthplans.FirstOrDefault());
            // var Count = await AsyncExecuter.CountAsync();
            var demo =ObjectMapper.Map<List<MonthlPlan>,List<MonthPlanDto>>(monthplans.ToList());
            return new PagedResultDto<MonthPlanDto>(Count,demo);

            // ObjectMapper.Map<List<MonthlPlan>, List<MonthPlanDto>>(monthplans);
        }
    }
}
