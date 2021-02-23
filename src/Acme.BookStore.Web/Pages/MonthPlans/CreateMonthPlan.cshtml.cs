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
