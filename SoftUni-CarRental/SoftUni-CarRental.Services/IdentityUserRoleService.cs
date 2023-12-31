﻿using Microsoft.AspNetCore.Identity;
using SoftUni_CarRental.Database;
using SoftUni_CarRental.Services.Interfaces;

namespace SoftUni_CarRental.Services
{
    public class IdentityUserRoleService : IIdentityUserRoleService
    {
        private readonly CarRentalDbContext dbContext;
        public IdentityUserRoleService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<IdentityUserRole<string>> AllRoles()
        {
            //This method return all the users with their roles
            return this.dbContext.UserRoles;
        }
    }
}
