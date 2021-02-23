using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.MonthPlans;
using Acme.BookStore.User;
using Acme.BookStore.Users;
using AutoMapper;
using System.Collections.Generic;

namespace Acme.BookStore
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
             CreateMap<Book, CreateUpdateBookDto>();
            CreateMap<CreateUpdateBookDto, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorLookupDto>();

            ///
            CreateMap<CreateStaffUserDto, StaffUser>();
            CreateMap<StaffUser, StaffUserDto>();

            ///
          //  CreateMap<List<CreateMonthPlanDto>, List<MonthlPlan>>();
           // CreateMap< List<MonthlPlan>,List<MonthPlanDto>>();
            CreateMap<MonthlPlan, MonthPlanDto>();

           
        }
    }
}
