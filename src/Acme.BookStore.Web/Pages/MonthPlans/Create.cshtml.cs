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
            /// �����ƻ�����
            /// </summary>
            [Required]
            [Display(Name = "�����ƻ�����")]
            public string WorkPlanContent { get; set; }
            /// <summary>
            /// �����ƻ��ƽ��ƽ�
            /// </summary>
            [CanBeNull]
            [Display(Name = "�����ƻ��ƽ��ƽ�")]
            public string WorkPlanTransfer { get; set; }
            /// <summary>
            /// �����ʱ��
            /// </summary>
            [Required]
            [Display(Name = "�����ʱ��")]
            public string ProposedCompletionTime { get; set; }
            /// <summary>
            /// �����ֵ
            /// </summary>
            [Required]
            [Display(Name = "�����ֵ")]
            public string TaskScore { get; set; }
            /// <summary>
            /// �����Ŀ��
            /// </summary>
            [Required]
            [Display(Name = "�����Ŀ��")]
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
