using LaCuevita.Areas.Admin.Models;
using LaCuevita.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Services.AdminManager
{
    public class AdminManager : IAdminManager
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public AdminManager(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _roleManager = roleManager;
        }

        public Task<bool> IsInRole(ApplicationUser user, string role)
        {
            return _userManager.IsInRoleAsync(user, role);
        }

        public List<IdentityRole> Roles()
        {
            return _roleManager.Roles.ToList();
        }

        public async Task UpdateRoles(UserRolesViewModel userRolesViewModel)
        {
            foreach (var userRole in userRolesViewModel.UserRoles)
            {
                var map = userRole.IsInRole;
                var user = userRole.User;
                foreach (var role in userRole.IsInRole.Keys)
                {
                    bool isInRole = await _userManager.IsInRoleAsync(user, role);

                    if ((map[role] && !isInRole) || (!map[role] && isInRole))
                        await AddOrDeleteRole(map[role], user, role);
                }
            }
        }

        private async Task AddOrDeleteRole(bool add, ApplicationUser user, string role)
        {
            if (add)
                await _userManager.AddToRoleAsync(user, role);
            else
                await _userManager.RemoveFromRoleAsync(user, role);
        }

        public List<ApplicationUser> Users()
        {
            return _userManager.Users.ToList();
        }
    }
}
