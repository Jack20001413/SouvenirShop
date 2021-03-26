using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Size : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}