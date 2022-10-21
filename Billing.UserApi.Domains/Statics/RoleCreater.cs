using System;
using System.Collections.Generic;

namespace Billing.UserApi.Domains.Statics
{
    public class RoleCreater
    {
        private static Dictionary<int, string> Roles { get; set; }
        public static string GetRole(int positionNumber)
        {
            if(Roles is null)
            {
                Roles = new Dictionary<int, string>();
                CompleteRoleList();
            }

            return Roles[positionNumber] ?? throw new ArgumentNullException("Nothing is in this position");
        }

        private static void CompleteRoleList()
        {
            Roles.Add(RoleNumber.Super_Admin, RoleName.SUPER_ADMIN);
        }
    }
}
