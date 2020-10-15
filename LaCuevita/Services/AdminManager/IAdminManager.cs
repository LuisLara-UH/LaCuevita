using LaCuevita.Areas.Admin.Models;
using LaCuevita.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Services.AdminManager
{
    public interface IAdminManager
    {
        List<ApplicationUser> Users();
        List<IdentityRole> Roles();
        Task<bool> IsInRole(ApplicationUser user, string role);
        Task UpdateRoles(UserRolesViewModel userRolesViewModel);
    }
}
