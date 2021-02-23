using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.MonthPlans
{
    public class CreateMonthPlanDto
    {
        public Guid StaffUserId { get; set; }
        /// <summary>
        /// 工作计划内容
        /// </summary>
        [CanBeNull]
        public string WorkPlanContent { get; set; }
        /// <summary>
        /// 工作计划推进移交
        /// </summary>
        [CanBeNull]
        public string WorkPlanTransfer { get; set; }
        /// <summary>
        /// 拟完成时间
        /// </summary>
        [CanBeNull]
        public string ProposedCompletionTime { get; set; }
        /// <summary>
        /// 任务分值
        /// </summary>
        [CanBeNull]
        public string TaskScore { get; set; }
        /// <summary>
        /// 拟完成目标
        /// </summary>
        [CanBeNull]
        public string ProposedGoal { get; set; }
        [CanBeNull]
        public int Year { get; set; }
        [CanBeNull]
        public int Month { get; set; }
        [CanBeNull]
        public int Day { get; set; }
        [CanBeNull]
        public string ActualCompletion { get; set; }
        [CanBeNull]
        /// <summary>
        /// 工作任务完成率
        /// </summary>
        public string TaskCompletionRate { get; set; }
        [CanBeNull]
        /// <summary>
        /// 实际完成时间
        /// </summary>
        public string ActualCompletionTime { get; set; }
        [CanBeNull]
        /// <summary>
        /// 自评分
        /// </summary>
        public string SelfRating { get; set; }
        [CanBeNull]
        /// <summary>
        /// 上级审核目标达成情况
        /// </summary>
        public string AchievementOfSuperiorReviewGoals { get; set; }
        [CanBeNull]
        /// <summary>
        /// 上级评分
        /// </summary>
        public string SuperiorScore { get; set; }
    }
}
