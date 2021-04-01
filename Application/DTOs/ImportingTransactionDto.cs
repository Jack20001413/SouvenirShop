using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ImportingTransactionDto
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

        [ForeignKey(nameof(ImportingOrderDto))]
        public int ImportingOrderId { get; set; }
        public virtual ImportingOrderDto ImportingOrder { get; set; }
    }
}