using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class Product : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}