using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaCuevita.Areas.Admin.Models;
using LaCuevita.Models;
using LaCuevita.Services.AdminManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaCuevita.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageUsersController : Controller
    {
        private IAdminManager _adminManager;
        public ManageUsersController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        public IActionResult Index()
        {
            var userRolesViewModel = new UserRolesViewModel(_adminManager);
            userRolesViewModel.Prepare().Wait();

            return View(userRolesViewModel);
        }

        [HttpPost]
        public IActionResult UpdateRoles(UserRolesViewModel userRolesViewModel)
        {
            _adminManager.UpdateRoles(userRolesViewModel).Wait();

            return Index();
        }
    }
}