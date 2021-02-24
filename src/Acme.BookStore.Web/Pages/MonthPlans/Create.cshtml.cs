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
          //  var data = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(MonthPlan);
            //var ka = ObjectMapper.Map<List< CreateMonthPlanViewModel>,List<CreateMonthPlanDto>>(MonthPlan);
            //    await _ImonthPlansService.CreateMonPlan(data);

        }
        //[FromBody] List<CreateMonthPlanViewModel> demolist
        public async Task<IActionResult> OnPostJoinAsync([FromBody] List<CreateMonthPlanViewModel> demolist)
        {

            if (ModelState.IsValid)
            {
                foreach (var monthplanModel in demolist)
                {
                    var monthplan = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(monthplanModel);
                    await _ImonthPlansService.CreateMonPlan(monthplan);
                }
            }
            else
            {
                foreach (var  key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors.ToList();
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }

         

            //if (ModelState.IsValid)
            //{
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var modelstate = ModelState[key];
            //        if (modelstate.Errors.Any())
            //        {
            //            //  return modelstate.Errors.FirstOrDefault().ErrorMessage;
            //        }
            //    }
            //}


            //if (ModelState.IsValid)
            //{
            //    foreach (var monthplanModel in demolist)
            //    {

            //        var monthplan = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(monthplanModel);
            //        await _ImonthPlansService.CreateMonPlan(monthplan);

            //    }
            //}


            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        foreach (var key in ModelState.Keys)
            //        {
            //            var modelstate = ModelState[key];
            //            if (modelstate.Errors.Any())
            //            {
            //               // return modelstate.Errors.FirstOrDefault().ErrorMessage;
            //            }
            //        }
            //        //foreach (var monthplanModel in demolist)
            //        //{
            //        //    var monthplan = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(monthplanModel);
            //        //    await _ImonthPlansService.CreateMonPlan(monthplan);

            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{

            //    ModelState.AddModelError("", ex.Message);
            //}






            //if (ModelState.IsValid)
            //{
            //    foreach (var monthplanModel in demolist)
            //    {
            //        var monthplan = ObjectMapper.Map<CreateMonthPlanViewModel, CreateMonthPlanDto>(monthplanModel);
            //        await _ImonthPlansService.CreateMonPlan(monthplan);

            //    }
            //}
            // var b = HttpContext.Request.Body;
            return NoContent();
        }
        public class CreateMonthPlanViewModel
        {

            public string StaffUserName { get; set; }

            public Guid ? StaffUserId  { get; set; }
            /// <summary>
            /// 工作计划内容
            /// </summary>
               [Required]
            [Display(Name = "工作计划内容")]
            public string WorkPlanContent { get; set; }
            /// <summary>
            /// 工作计划推进移交
            /// </summary>
            [Required]
            [Display(Name = "工作计划推进移交")]
            public string WorkPlanTransfer { get; set; }
            /// <summary>
            /// 拟完成时间
            /// </summary>
          
            [Display(Name = "拟完成时间")]
            public string ProposedCompletionTime { get; set; }
            /// <summary>
            /// 任务分值
            /// </summary>
           
            [Display(Name = "任务分值")]
            public string TaskScore { get; set; }
            /// <summary>
            /// 拟完成目标
            /// </summary>
         
            [Display(Name = "拟完成目标")]
            public string ProposedGoal { get; set; }
            //[Required]
            //public int Year { get; set; }
            //[Required]
            //public int Month { get; set; }
            //[Required]
            //public int Day { get; set; }
       
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
         
            public string AchievementOfSuperiorReviewGoals { get; set; }
            /// <summary>
            /// 上级评分
            /// </summary>
         
            public string SuperiorScore { get; set; }

        }
    }
}
