using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Acme.BookStore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;


namespace Acme.BookStore.MonthPlans
{
     public class EfCoreMonthPlanRepository:
        EfCoreRepository<BookStoreDbContext,MonthlPlan,Guid>,IMonthPlanRepository
    {
        public EfCoreMonthPlanRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider):
            base(dbContextProvider)
        {

        }

        public async Task<List<MonthlPlan>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            return await DbSet.OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
