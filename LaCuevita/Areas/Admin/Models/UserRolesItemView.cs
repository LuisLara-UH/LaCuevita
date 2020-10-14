using LaCuevita.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LaCuevita.Extensions.Roles.RoleExtensions;

namespace LaCuevita.Areas.Admin.Models
{
    public class UserRolesItemView
    {
        private UserManager<ApplicationUser> _userManager;
        public UserRolesItemView(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            _user = user;

            _userManager = userManager;
        }

        public async Task Prepare()
        {
            IsAdmin = await _userManager.IsInRoleAsync(_user, RoleHelper.RoleValueMap[RoleType.Admin]);
            IsSeller = await _userManager.IsInRoleAsync(_user, RoleHelper.RoleValueMap[RoleType.Seller]);
            IsClient = await _userManager.IsInRoleAsync(_user, RoleHelper.RoleValueMap[RoleType.Client]);
        }

        #region Properties
        private ApplicationUser _user;
        public ApplicationUser User
        {
            get => _user;
        }

        public bool IsAdmin { get; set; }
        public bool IsSeller { get; set; }
        public bool IsClient { get; set; }
        #endregion
    }
}
