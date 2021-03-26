using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Permission : EntityBase, IAggregateRoot
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }
    }
}