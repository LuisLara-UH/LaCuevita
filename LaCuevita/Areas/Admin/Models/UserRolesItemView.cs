using LaCuevita.Models;
using LaCuevita.Services.AdminManager;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Areas.Admin.Models
{
    public class UserRolesItemView
    {
        private IAdminManager _adminManager;
        public UserRolesItemView(ApplicationUser user, 
                                 IAdminManager adminManager)
        {
            _user = user;

            _adminManager = adminManager;
        }

        public async Task Prepare()
        {
            IsInRole = new Dictionary<string, bool>();
            var roles = _adminManager.Roles();

            foreach(var role in roles)
                IsInRole[role.Name] = 
                    await _adminManager.IsInRole(_user, role.Name);
        }

        #region Properties
        private ApplicationUser _user;
        public ApplicationUser User
        {
            get => _user;
        }

        public Dictionary<string, bool> IsInRole { get; set; }
        #endregion
    }
}
