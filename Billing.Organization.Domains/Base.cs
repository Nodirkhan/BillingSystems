using System;

namespace Billing.Organization.Domains
{
    public class Base : BaseEntity
    {
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid LastModifiedBy { get; set; }

        public void CreateEntity(Guid userId)
        {
            CreatedBy = userId;
            Active = true;
            LastModifiedDate = CreatedDate = DateTime.Now;
            LastModifiedBy = userId;
        }
        public void ModifyEntity(Guid UserId, bool active)
        {
            LastModifiedDate = DateTime.Now;
            LastModifiedBy = UserId;
            Active = active;
        }
    }
}
