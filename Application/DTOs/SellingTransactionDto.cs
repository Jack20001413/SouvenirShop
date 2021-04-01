using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class SellingTransactionDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [ForeignKey(nameof(ProductDetailDto))]
        public int ProductDetailId { get; set; }
        public virtual ProductDetailDto ProductDetail { get; set; }

        [ForeignKey(nameof(SellingOrderDto))]
        public int SellingOrderId { get; set; }
        public virtual SellingOrderDto SellingOrder { get; set; }
    }
}