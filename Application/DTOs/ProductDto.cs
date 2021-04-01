using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class ProductDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey(nameof(SubCategoryDto))]
        public int SubCategoryId { get; set; }
        public virtual SubCategoryDto SubCategory { get; set; }

    }
}