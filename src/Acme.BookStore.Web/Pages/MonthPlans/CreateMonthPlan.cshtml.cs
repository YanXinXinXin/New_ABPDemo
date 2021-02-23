using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.MonthPlans;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages.MonthPlans
{
    public class CreateMonthPlanModel : AbpPageModel
    {
        [BindProperty]
        public CreateMonthlPlanViewModel MonthlPlan { get; set; }
        private readonly IMonthPlansService _monthlPlansService;

        public CreateMonthPlanModel(IMonthPlansService monthlPlansService)
        {
            _monthlPlansService = monthlPlansService;
        }
       
        public void OnGet()
        {
            MonthlPlan = new CreateMonthlPlanViewModel();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("<script>alert('122')</script>");
            }

            var data = ObjectMapper.Map<CreateMonthlPlanViewModel, CreateMonthPlanDto>(MonthlPlan);
        //   await _monthlPlansService.CreateMonPlan(data);
            return NoContent();
        }
        public class CreateMonthlPlanViewModel
        {
            public Guid StaffUserId { get; set; }
            /// <summary>
            /// 工作计划内容
            /// </summary>
            [Required]
            [Display(Name = "工作计划内容")]
            public string WorkPlanContent { get; set; }
            /// <summary>
            /// 工作计划推进移交
            /// </summary>
            [CanBeNull]
            [Display(Name = "工作计划推进移交")]
            public string WorkPlanTransfer { get; set; }
            /// <summary>
            /// 拟完成时间
            /// </summary>
            [Required]
            [Display(Name = "拟完成时间")]
            public string ProposedCompletionTime { get; set; }
            /// <summary>
            /// 任务分值
            /// </summary>
            [Required]
            [Display(Name = "任务分值")]
            public string TaskScore { get; set; }
            /// <summary>
            /// 拟完成目标
            /// </summary>
            [Required]
            [Display(Name = "拟完成目标")]
            public string ProposedGoal { get; set; }
            [Required]
            public int Year { get; set; }
            [Required]
            public int Month { get; set; }
            [Required]
            public int Day { get; set; }


        }

    }
}
