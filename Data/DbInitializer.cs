using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Api.Models;

namespace SupportDesk.Api.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SupportDeskDbContext>();

            // 1. Veritabanı tablolarının varlığını kontrol et ve güncelle
            await context.Database.MigrateAsync();

            // 2. Varsayılan Şirket yoksa oluştur
            if (!await context.Companies.AnyAsync())
            {
                var defaultCompany = new Company
                {
                    Name = "Genel Merkez"
                };
                await context.Companies.AddAsync(defaultCompany);
                await context.SaveChangesAsync();
            }

            var company = await context.Companies.FirstAsync();

            // 3. Kullanıcılar yoksa 3 farklı rolde test kullanıcısını otomatik ekle
            if (!await context.Users.AnyAsync())
            {
                var passwordHasher = new PasswordHasher<User>();

                var adminUser = new User
                {
                    FullName = "Sistem Yöneticisi",
                    Email = "admin@supportdesk.com",
                    Role = UserRoles.Admin, // Oluşturduğumuz UserRoles sınıfından geliyor
                    CompanyId = company.Id
                };
                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123!");

                var staffUser = new User
                {
                    FullName = "Destek Personeli",
                    Email = "staff@supportdesk.com",
                    Role = UserRoles.SupportStaff,
                    CompanyId = company.Id
                };
                staffUser.PasswordHash = passwordHasher.HashPassword(staffUser, "Staff123!");

                var customerUser = new User
                {
                    FullName = "Müşteri Kullanıcısı",
                    Email = "customer@supportdesk.com",
                    Role = UserRoles.Customer,
                    CompanyId = company.Id
                };
                customerUser.PasswordHash = passwordHasher.HashPassword(customerUser, "Customer123!");

                await context.Users.AddRangeAsync(adminUser, staffUser, customerUser);
                await context.SaveChangesAsync();
                
                // 4. Varsayılan Kategori yoksa oluştur
        if (!await context.Categories.AnyAsync())
        {
            var defaultCategory = new Category
            {
                Name = "Genel Destek"
            };
            await context.Categories.AddAsync(defaultCategory);
            await context.SaveChangesAsync();
        }
            }
        }
    }
}