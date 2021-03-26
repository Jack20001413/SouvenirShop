using System;
using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Employee : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<ImportingOrder> ImportingOrders { get; set; }
    }
}