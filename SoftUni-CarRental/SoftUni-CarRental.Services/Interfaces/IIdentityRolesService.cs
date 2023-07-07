using Microsoft.AspNetCore.Identity;
using SoftUni_CarRental.Models.Models;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface IIdentityRolesService
    {
        IEnumerable<Role> AllRoles();
        void CreateMemberUser(User user,List<Role> allRoles,List<IdentityUserRole<string>> userRoles);
    }
}
