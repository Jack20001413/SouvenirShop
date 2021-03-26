using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class ProductDetail : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public int ImportingPrice { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int SizeId { get; set; }
        public virtual Size Size { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual ICollection<SellingTransaction> SellingTransactions { get; set; }
        public virtual ICollection<ImportingTransaction> ImportingTransactions { get; set; }
    }
}