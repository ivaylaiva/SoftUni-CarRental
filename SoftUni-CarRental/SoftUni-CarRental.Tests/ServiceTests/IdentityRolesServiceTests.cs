using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class IdentityRolesServiceTests
    {
        [Test]
        public async Task AllRolesTest()
        {
            var db = ContextGenerator.Instance;

            var identityRolesService = new IdentityRolesService(db);

            for (int i = 0; i < 3; i++)
            {
                Role role = new Role()
                {
                    Name = "Test",
                };
                db.Roles.Add(role);
            }
            await db.SaveChangesAsync();


            identityRolesService
                 .AllRoles();


            Assert.AreEqual(3, await db.Roles.CountAsync());
        }
        [Test]
        public async Task CreateMemberUserTest()
        {
            var db = ContextGenerator.Instance;
            var identityRolesService = new IdentityRolesService(db);
            List<Role> roles = new List<Role>();
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            User user = new User()
            {
                UserName = "Test",
                Email = "Test"
            };


            Role role = new Role()
            {
                Name = "Test",
            };
            roles.Add(role);


            IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = roles.First(r => r.Name == "Test").Id
            };
            userRoles.Add(identityUserRole);
            db.UserRoles.Add(identityUserRole);

            await db.SaveChangesAsync();
            identityRolesService.CreateMemberUser(user, roles, userRoles);

            Assert.AreEqual(3, await db.UserRoles.CountAsync());
        }
    }
}
