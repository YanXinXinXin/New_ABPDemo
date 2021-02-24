
using Acme.BookStore.User;
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
        private readonly IStaffUserRepository _staffUserRepository;

        public MonthPlansService(IMonthPlanRepository monthPlanRepository,
            MonthPlanManger monthPlanManger,
            IStaffUserRepository staffUserRepository
            )
        {
            _monthPlanRepository = monthPlanRepository;
            _monthPlanManger = monthPlanManger;
            _staffUserRepository = staffUserRepository;
        }
        public async Task<MonthPlanDto> CreateMonPlan(CreateMonthPlanDto data)
        {
            var user = await _staffUserRepository.FindByNameAsync(data.StaffUserName);
            var MonthlPlan = _monthPlanManger.CreateAsync(data.WorkPlanContent, data.WorkPlanTransfer, data.ProposedCompletionTime, data.TaskScore,
          data.ProposedGoal, /*data.Year, data.Month, data.Day,*/data.ActualCompletion, data.TaskCompletionRate
          , data.ActualCompletionTime, data.SelfRating, data.AchievementOfSuperiorReviewGoals, data.SuperiorScore);

            MonthlPlan.StaffUserId = user.Id;
            await _monthPlanRepository.InsertAsync(MonthlPlan);
            return ObjectMapper.Map<MonthlPlan, MonthPlanDto>(MonthlPlan);
        }

        public async Task<PagedResultDto<MonthPlanDto>> GetListAsync(GetMonthPlansListDto data)
        {
            if (data.Sorting.IsNullOrWhiteSpace())
            {
                data.Sorting = nameof(MonthlPlan.WorkPlanContent);
            }
            var monthplans = await _monthPlanRepository.GetListAsync(
                 data.SkipCount,
                 data.MaxResultCount,
                 data.Sorting
                );

            // var monthplans= await _monthPlanRepository.GetListAsync();
            var Count = await _monthPlanRepository.GetCountAsync();
            //var test = ObjectMapper.Map<MonthlPlan, MonthPlanDto>(monthplans.FirstOrDefault());
            // var Count = await AsyncExecuter.CountAsync();
            var demo = ObjectMapper.Map<List<MonthlPlan>, List<MonthPlanDto>>(monthplans.ToList());
            return new PagedResultDto<MonthPlanDto>(Count, demo);

            // ObjectMapper.Map<List<MonthlPlan>, List<MonthPlanDto>>(monthplans);
        }
    }
}
