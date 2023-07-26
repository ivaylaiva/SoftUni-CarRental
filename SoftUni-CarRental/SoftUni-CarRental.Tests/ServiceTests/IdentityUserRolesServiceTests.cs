using Microsoft.AspNetCore.Identity;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;

namespace SoftUni_CarRental.Tests.ServiceTests
{
    public class IdentityUserRolesServiceTests
    {
        [Test]
        public async Task AllRolesTest()
        {
            var db = ContextGenerator.Instance;

            var identityUserRolesService = new IdentityUserRoleService(db);

            User user = new User()
            {
                UserName = "Test",
                Email = "Test@abv.bg"
            };
            Role role = new Role()
            {
                Name = "Test",
            };

            IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
            db.UserRoles.Add(identityUserRole);
            await db.SaveChangesAsync();

            var result = identityUserRolesService.AllRoles();

            Assert.AreEqual(1, result.Count());
        }
    }
}
