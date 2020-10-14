using LaCuevita.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Areas.Admin.Models
{
    public class UserRolesViewModel
    {
        private UserManager<ApplicationUser> _userManager;
        public UserRolesViewModel(List<ApplicationUser> users, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            _users = users;

            _userRoles = new List<UserRolesItemView>();
        }

        public async Task Prepare()
        {
            foreach (var user in _users)
            {
                var userRole = new UserRolesItemView(user, _userManager);
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
        #endregion
    }
}
