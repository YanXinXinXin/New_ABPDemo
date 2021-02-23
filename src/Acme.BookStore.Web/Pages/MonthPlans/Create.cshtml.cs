using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.MonthPlans;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages.MonthPlans
{
    public class CreateModel : AbpPageModel
    {

        private readonly IMonthPlansService _ImonthPlansService;

        public CreateModel(IMonthPlansService monthPlansService)
        {
            _ImonthPlansService = monthPlansService;
        }
        [BindProperty]
        public CreateMonthPlanViewModel MonthPlan { get; set; }
        public void OnGet()
        {
            MonthPlan = new CreateMonthPlanViewModel();
        }
        public async Task OnPost()
        {
            //MonthPlan = new CreateMonthPlanViewModel();
            var data = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(MonthPlan);
            //var ka = ObjectMapper.Map<List< CreateMonthPlanViewModel>,List<CreateMonthPlanDto>>(MonthPlan);
            //    await _ImonthPlansService.CreateMonPlan(data);

        }
        public async Task<IActionResult> OnPostJoinAsync([FromBody] List<CreateMonthPlanViewModel> demo)
        {
            var b = HttpContext.Request.Body;
            return Page();
        }
        public class CreateMonthPlanViewModel
        {
            public Guid? StaffUserId { get; set; }
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
