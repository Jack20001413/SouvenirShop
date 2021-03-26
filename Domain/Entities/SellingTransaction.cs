using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class SellingTransaction : EntityBase, IAggregateRoot
    {
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int ProductDetailId { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }

        public int SellingOrderId { get; set; }
        public virtual SellingOrder SellingOrder { get; set; }
    }
}