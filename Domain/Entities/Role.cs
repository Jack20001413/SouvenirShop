using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Role : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<GrantPermission> GrantPermissions { get; set; }
    }

}