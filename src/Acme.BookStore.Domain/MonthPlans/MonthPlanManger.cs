using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.MonthPlans
{
     public  class MonthPlanManger: DomainService
    {
        private readonly IMonthPlanRepository _monthPlanRepository;

        public MonthPlanManger(IMonthPlanRepository monthPlanRepository)
        {
            _monthPlanRepository = monthPlanRepository;
        }
        public  MonthlPlan CreateAsync(
          [CanBeNull] string workPlanContent, [CanBeNull] string workPlanTransfer, [CanBeNull] string proposedCompletionTime,
           [CanBeNull] string taskScore, [CanBeNull] string proposedGoal, int year, int month, int day,
          [CanBeNull] string actualCompletion, [CanBeNull] string taskCompletionRate, [CanBeNull] string actualCompletionTime, [CanBeNull] string selfRating,
           [CanBeNull] string achievementOfSuperiorReviewGoals, [CanBeNull] string superiorScore )
        {
            return new MonthlPlan(GuidGenerator.Create(), workPlanContent, workPlanTransfer, proposedCompletionTime, taskScore
               , proposedGoal, year, month, day, actualCompletion, taskCompletionRate, actualCompletionTime,
               selfRating, achievementOfSuperiorReviewGoals, superiorScore);
        }
    }
}
