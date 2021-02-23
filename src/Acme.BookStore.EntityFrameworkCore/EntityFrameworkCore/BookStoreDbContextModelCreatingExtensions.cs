using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.MonthPlans;
using Acme.BookStore.User;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Acme.BookStore.EntityFrameworkCore
{
    public static class BookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Book>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Books", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
                
                b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
            });

            builder.Entity<Author>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "Authors",
                    BookStoreConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.MaxNameLength);
                b.HasIndex(x => x.Name);
            });
            builder.Entity<StaffUser>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "StaffUsers",
                    BookStoreConsts.DbSchema);

                b.ConfigureByConvention();

                b.Property(x => x.UserName)
                    .IsRequired()
                    .HasMaxLength(AuthorConsts.MaxNameLength);
                //b.HasIndex(x => x.Name);
            });
            builder.Entity<MonthlPlan>(b =>
            {
                b.ToTable(BookStoreConsts.DbTablePrefix + "MonthlPlanTables", BookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                //b.Property(x => x.).IsRequired().HasMaxLength(128);

                b.HasOne<StaffUser>().WithMany().HasForeignKey(x => x.StaffUserId).IsRequired();
            });
        }
    }
}
