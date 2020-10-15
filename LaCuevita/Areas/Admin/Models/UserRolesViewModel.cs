using LaCuevita.Models;
using LaCuevita.Services.AdminManager;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        private IAdminManager _adminManager;
        public UserRolesViewModel(IAdminManager adminManager)
        {
            _adminManager = adminManager;

            _users = _adminManager.Users();

            _userRoles = new List<UserRolesItemView>();
        }

        public async Task Prepare()
        {
            _roles = _adminManager.Roles();

            foreach (var user in _users)
            {
                var userRole = new UserRolesItemView(user, _adminManager);
                await userRole.Prepare();
                _userRoles.Add(userRole);
            }
        }

        #region Properties
        private List<ApplicationUser> _users;
        public List<ApplicationUser> Users
        {
            get => _users;
        }

        private List<UserRolesItemView> _userRoles;
        public List<UserRolesItemView> UserRoles
        {
            get => _userRoles;
        }

        private List<IdentityRole> _roles;
        public List<IdentityRole> Roles
        {
            get => _roles;
        }
        #endregion
    }
}
