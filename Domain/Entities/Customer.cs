using System;
using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Customer : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string IsValid { get; set; }

        public virtual ICollection<SellingOrder> SellingOrders { get; set; }
    }
}