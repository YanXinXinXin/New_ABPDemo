using Acme.BookStore.Authors;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
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
          [NotNull] string workPlanContent, [NotNull] string workPlanTransfer, [NotNull] string proposedCompletionTime,
           [NotNull] string taskScore, [NotNull] string proposedGoal, /*int year, int month, int day,*/
          [CanBeNull] string actualCompletion, [CanBeNull] string taskCompletionRate, [CanBeNull] string actualCompletionTime, [CanBeNull] string selfRating,
           [CanBeNull] string achievementOfSuperiorReviewGoals, [CanBeNull] string superiorScore )
        {
            return new MonthlPlan(GuidGenerator.Create(), workPlanContent, workPlanTransfer, proposedCompletionTime, taskScore
           , proposedGoal,/* year, month, day,*/ actualCompletion, taskCompletionRate, actualCompletionTime,
           selfRating, achievementOfSuperiorReviewGoals, superiorScore);
            //if (string.IsNullOrWhiteSpace(workPlanContent) || string.IsNullOrWhiteSpace(workPlanTransfer) ||
            //    string.IsNullOrWhiteSpace(proposedCompletionTime) ||  string.IsNullOrWhiteSpace(taskScore) ||
            //    string.IsNullOrWhiteSpace(proposedGoal))
            //{
            //    //throw new AuthorAlreadyExistsException("参数异常");
            //    return null;
            //}
            //else
            //{
            //    return new MonthlPlan(GuidGenerator.Create(), workPlanContent, workPlanTransfer, proposedCompletionTime, taskScore
            //  , proposedGoal,/* year, month, day,*/ actualCompletion, taskCompletionRate, actualCompletionTime,
            //  selfRating, achievementOfSuperiorReviewGoals, superiorScore);
          // }
          
            //Check.NotNullOrWhiteSpace(workPlanContent, nameof(workPlanContent));


           
        }
    }
}
