using System.Collections.Generic;
using static Billing.UserApi.Domains.Statics.PermissionFactory;

namespace Billing.UserApi.Domains.Statics
{
    public static class PermissionCreater
    {
        private static Dictionary<int, RolePermission> PermissionCollection { get; set; } 

        private static void SetListPermission()
        {
            PermissionCollection.Add(RoleNumber.Super_Admin, new SuperAdminRole());
        }

        public static void GetPermission(int position,List<string> permissions)
        {
            if(PermissionCollection is null) 
            {
                PermissionCollection = new Dictionary<int, RolePermission>();
                SetListPermission();
            }

            var rolePermission = PermissionCollection[position];
            rolePermission.Set(permissions);
        }
    }
}
