using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLogin.Models
{
    public static class RoleName
    {
        public const string RoleAdmin = "Admin";
        public const string RoleClient = "Client";
        public const string RoleAdminOrCustommer = RoleAdmin + "," + RoleClient;
    }
}


