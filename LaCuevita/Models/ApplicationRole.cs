using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaCuevita.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(RoleType role) : base(RoleHelper.RoleValueMap[role])
        { 
        }
    }

    public enum RoleType
    { 
        Admin, Seller, Client
    }

    public static class RoleHelper
    {
        public static Dictionary<RoleType, string> RoleValueMap = new Dictionary<RoleType, string>
        {
            { RoleType.Admin, "Admin" },
            { RoleType.Seller, "Seller"},
            { RoleType.Client, "Client"}
        };

        public static Dictionary<string, RoleType> ValueRoleMap = new Dictionary<string, RoleType>
        {
            { "Admin", RoleType.Admin},
            { "Seller", RoleType.Seller},
            { "Client", RoleType.Client}
        };
    }
}
