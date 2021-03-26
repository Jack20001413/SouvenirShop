using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Supplier : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ImportingOrder> Orders { get; set; }
    }
}