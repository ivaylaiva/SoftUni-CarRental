using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Database
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var pwr = "pass123";
            var pwrHasher = new PasswordHasher<User>();
            var adminRole = new Role
            {
                Name = "Admin"
            };
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var memberRole = new Role
            {
                Name = "Member"
            };
            memberRole.NormalizedName = memberRole.Name.ToUpper();

            List<Role> roles = new List<Role>()
            {
                memberRole,
                adminRole,
            };
            modelBuilder.Entity<Role>().HasData(roles);

            var adminUser = new User
            {
                UserName = "admin@carrental.com",
                NormalizedUserName = "ADMIN@CARRENTAL.COM",
                Email = "admin@carrental.com",
                NormalizedEmail = "ADMIN@CARRENTAL.COM",
            };
            adminUser.PasswordHash = pwrHasher.HashPassword(adminUser,pwr);

            var memberUser = new User
            {
                UserName = "member@carrental.com",
                NormalizedUserName = "MEMBER@CARRENTAL.COM",
                Email = "member@carrental.com",
                NormalizedEmail = "MEMBER@CARRENTAL.COM",
            };
            memberUser.PasswordHash = pwrHasher.HashPassword(memberUser,pwr);

            List<User> users = new List<User>()
            {
                adminUser,
                memberUser,
            };
            modelBuilder.Entity<User>().HasData(users);

            //SeedUserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(r => r.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(r => r.Name == "Member").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
