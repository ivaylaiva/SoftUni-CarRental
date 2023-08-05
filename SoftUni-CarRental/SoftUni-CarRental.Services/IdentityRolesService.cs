using Microsoft.AspNetCore.Identity;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Models.Models;
using SoftUni_CarRental.Services.Interfaces;

namespace SoftUni_CarRental.Services
{
    public class IdentityRolesService : IIdentityRolesService
    {
        private readonly CarRentalDbContext dbContext;
        public IdentityRolesService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Role> AllRoles()
        {
            return this.dbContext.Roles;
        }

        public void CreateMemberUser(User user, List<Role> allRoles, List<IdentityUserRole<string>> userRoles)
        {
            var newUser = new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = allRoles.First(r => r.Name == "Member").Id
            };
            this.dbContext.UserRoles.Add(newUser);
            this.dbContext.SaveChanges();
        }
    }
}