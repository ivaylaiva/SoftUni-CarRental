using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services;
using SoftUni_CarRental.Services.Interfaces;

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
    }
}
