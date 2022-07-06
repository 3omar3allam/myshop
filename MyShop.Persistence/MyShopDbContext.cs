using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Entities;

namespace MyShop.Persistence
{
    public class MyShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SetConstraints()
                .SeedUsersAndRoles()
                .SeedTestData();
        }
    }
}
