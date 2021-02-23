using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.MonthPlans;
using Acme.BookStore.Users;
using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using static Acme.BookStore.Web.Pages.Authors.CreateModalModel;
using static Acme.BookStore.Web.Pages.MonthPlans.CreateModel;
using static Acme.BookStore.Web.Pages.Users.CreateModelModel;

namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();

          CreateMap<CreateAuthorViewModel, CreateAuthorDto>();

            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            CreateMap<PagedResultDto<AuthorDto>, AuthorDto>();
            CreateMap<PagedResultDto<AuthorDto>,List<AuthorDto>>();
            //CreateMap<List<AuthorDto>, List< CreateAuthorViewModel>>();

            ///
            CreateMap< CreateStaffUserViewModel, CreateStaffUserDto>();

            CreateMap<CreateStaffUserViewModel,CreateStaffUserDto>();

            ///
            CreateMap<CreateMonthPlanViewModel, CreateMonthPlanDto>();
            //CreateMap<List< CreateMonthPlanViewModel>,List< CreateMonthPlanDto>>();
            //
            //CreateMap<List<MonthlPlan>, List<MonthPlanDto>>();
        }
    }
}
