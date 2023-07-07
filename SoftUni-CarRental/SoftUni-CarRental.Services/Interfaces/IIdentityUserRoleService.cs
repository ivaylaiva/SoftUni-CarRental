using Microsoft.AspNetCore.Identity;

namespace SoftUni_CarRental.Services.Interfaces
{
    public interface IIdentityUserRoleService
    {
        IEnumerable<IdentityUserRole<string>> AllRoles();
    }
}
