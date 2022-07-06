using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Core.Common;
using MyShop.Core.Entities;

namespace MyShop.Persistence
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder SetConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Description)
                    .HasMaxLength(500);

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasPrecision(14, 2);

                entity.HasOne(p => p.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(p => p.Quantity)
                    .IsRequired();

                entity.Property(p => p.Percentage)
                    .IsRequired()
                    .HasPrecision(4, 2);

                entity.HasOne(p => p.Product)
                    .WithOne(p => p.Discount)
                    .HasForeignKey<Discount>(p => p.ProductId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(p => p.ProductId)
                    .IsRequired();

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasPrecision(14, 2);

                entity.HasOne(p => p.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(p => p.CustomerId);

                entity.HasOne(p => p.Product)
                    .WithMany()
                    .HasForeignKey(p => p.ProductId);
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(p => p.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            return modelBuilder;
        }

        public static ModelBuilder SeedUsersAndRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(new[]
                {
                    new IdentityRole(Constants.Roles.AdminRoleName)
                    {
                        Id = Constants.Roles.AdminRoleId,
                        NormalizedName = Constants.Roles.AdminRoleName.ToUpper(),
                    },
                    new IdentityRole(Constants.Roles.CustomerRoleName)
                    {
                        Id =  Constants.Roles.CustomerRoleId,
                        NormalizedName = Constants.Roles.CustomerRoleName.ToUpper(),
                    },
                });


            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = "cb84d5d9-98dd-4f6b-9d27-5dba4955dc5a",
                DisplayName = "Test Admin",
                Email = "admin@myshop.com",
                NormalizedEmail = "ADMIN@MYSHOP.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+201234567890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "f46db2be-8e5c-47d2-bd85-399ed98c8be2",
            };

            var customerUser = new ApplicationUser
            {
                Id = "ce07ec9b-df25-4bf9-b82e-258547f5829a",
                DisplayName = "Test Customer",
                Email = "customer@myshop.com",
                NormalizedEmail = "CUSTOMER@MYSHOP.COM",
                UserName = "customer",
                NormalizedUserName = "CUSTOMER",
                PhoneNumber = "+201234567891",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "3ec2a34d-44eb-428d-9b79-dc87394e121a",
            };

            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
            customerUser.PasswordHash = passwordHasher.HashPassword(customerUser, "123456");


            modelBuilder.Entity<ApplicationUser>()
                .HasData(new[] { adminUser, customerUser });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new[]
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = Constants.Roles.AdminRoleId,
                        UserId = adminUser.Id,
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId =  Constants.Roles.CustomerRoleId,
                        UserId = customerUser.Id,
                    },
                });

            return modelBuilder;
        }

        public static ModelBuilder SeedTestData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new[] {
                    new Category
                    {
                        Id = 1,
                        Name = "TVs",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Laptops",
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Sound Systems",
                    },
                });

            modelBuilder.Entity<Product>()
                .HasData(new[]
                {
                    new Product
                    {
                        Id = 1,
                        Name = "LG Smart TV 50\"",
                        CategoryId = 1,
                        Description = "Super AMOLED 4K Display",
                        Price = 15000,
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Lenovo Thinkpad 15.6\" - 16 GB RAM",
                        CategoryId = 2,
                        Price = 22000,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Dell Inspiron xyz",
                        CategoryId = 2,
                        Price = 18000,
                    },
                });

            modelBuilder.Entity<Discount>()
                .HasData(new[]
                {
                    new Discount
                    {
                        Id = 1,
                        ProductId = 2,
                        Quantity = 2,
                        Percentage = 0.30m,
                    },
                });

            return modelBuilder;
        }
    }
}
