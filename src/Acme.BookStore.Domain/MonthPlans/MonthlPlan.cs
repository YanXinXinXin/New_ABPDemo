using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.MonthPlans
{
      public class MonthlPlan: FullAuditedAggregateRoot<Guid>
    {
        public Guid StaffUserId { get; set; }
        /// <summary>
        /// 工作计划内容
        /// </summary>
        public string WorkPlanContent { get; set; }
        /// <summary>
        /// 工作计划推进移交
        /// </summary>
        public string  WorkPlanTransfer { get; set; }
        /// <summary>
        /// 拟完成时间
        /// </summary>
        public string   ProposedCompletionTime { get; set; }
        /// <summary>
        /// 任务分值
        /// </summary>
        public  string TaskScore { get; set; }
        /// <summary>
        /// 拟完成目标
        /// </summary>
        public string ProposedGoal { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        /// <summary>
        /// 实际完成情况
        /// </summary>
        public string ActualCompletion { get; set; }
        /// <summary>
        /// 工作任务完成率
        /// </summary>
        public string TaskCompletionRate { get; set; }
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string ActualCompletionTime { get; set; }
        /// <summary>
        /// 自评分
        /// </summary>
        public string SelfRating { get; set; }
        /// <summary>
        /// 上级审核目标达成情况
        /// </summary>
        public string  AchievementOfSuperiorReviewGoals { get; set; }
        /// <summary>
        /// 上级评分
        /// </summary>
        public string SuperiorScore { get; set; }
     




        private MonthlPlan()
        {
            
        }
        internal MonthlPlan(Guid id, [CanBeNull] string workPlanContent, [CanBeNull] string workPlanTransfer, [CanBeNull] string proposedCompletionTime,
           [CanBeNull] string taskScore, [CanBeNull] string proposedGoal, int year, int month, int day,
          [CanBeNull] string actualCompletion , [CanBeNull] string taskCompletionRate , [CanBeNull] string actualCompletionTime, [CanBeNull] string selfRating,
           [CanBeNull] string  achievementOfSuperiorReviewGoals , [CanBeNull] string superiorScore
            ) : base(id)
        {
            WorkPlanContent = workPlanContent; WorkPlanTransfer = workPlanTransfer; ProposedCompletionTime = proposedCompletionTime;
            TaskScore = taskScore; ProposedGoal = proposedGoal; Year = year; Month = month; Day = day;
            ActualCompletion = actualCompletion; TaskCompletionRate = taskCompletionRate; ActualCompletionTime = actualCompletionTime;
            SelfRating = selfRating; AchievementOfSuperiorReviewGoals = achievementOfSuperiorReviewGoals; SuperiorScore = superiorScore;
        }
    }
}
