using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SellingPrice { get; set; }
        
        [ForeignKey(nameof(SubCategoryDto))]
        public int SubCategoryId { get; set; }
        public virtual SubCategoryDto SubCategory { get; set; }

    }
}