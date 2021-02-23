using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.MonthPlans
{
    public class MonthPlanDto: Volo.Abp.Application.Dtos.FullAuditedEntityDto<Guid>
    {
        public Guid StaffUserId { get; set; }
        /// <summary>
        /// 工作计划内容
        /// </summary>
        public string WorkPlanContent { get; set; }
        /// <summary>
        /// 工作计划推进移交
        /// </summary>
        public string WorkPlanTransfer { get; set; }
        /// <summary>
        /// 拟完成时间
        /// </summary>
        public string ProposedCompletionTime { get; set; }
        /// <summary>
        /// 任务分值
        /// </summary>
        public string TaskScore { get; set; }
        /// <summary>`
        /// 拟完成目标
        /// </summary>
        public string ProposedGoal { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public string ActualCompletion { get; set; }
      
        public string TaskCompletionRate { get; set; }
       
        public string ActualCompletionTime { get; set; }
      
        public string SelfRating { get; set; }
       
        public string AchievementOfSuperiorReviewGoals { get; set; }
       
        public string SuperiorScore { get; set; }
    }
}
