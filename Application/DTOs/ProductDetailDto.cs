using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDetailDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }
        public int ImportingPrice { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey(nameof(ColorDto))]
        public int ColorId { get; set; }
        public virtual ColorDto Color { get; set; }

        [ForeignKey(nameof(SizeDto))]
        public int SizeId { get; set; }
        public virtual SizeDto Size { get; set; }

        [ForeignKey(nameof(ProductDto))]
        public int ProductId { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}