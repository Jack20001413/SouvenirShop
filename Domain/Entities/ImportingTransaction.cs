using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class ImportingTransaction : EntityBase, IAggregateRoot
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        
        public int ProductDetailId { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }

        public int ImportingOrderId { get; set; }
        public virtual ImportingOrder ImportingOrder { get; set; }
    }
}