using System.Collections.Generic;

namespace Billing.UserApi.Domains.Statics
{
    public class PermissionFactory
    {
        public abstract class RolePermission
        {
            public abstract void Set(List<string> permissions);
        }

        public class SuperAdminRole : RolePermission
        {
            public override void Set(List<string> permissions)
            {
                permissions.Add(PermissionList.MODIFY_USER); 
                permissions.Add(PermissionList.VIEW_USER); 
                permissions.Add(PermissionList.DELETE_USER); 
            }
        }
    }
}
