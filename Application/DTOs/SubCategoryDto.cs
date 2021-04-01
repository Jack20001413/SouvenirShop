using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class SubCategoryDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(CategoryDto))]
        public int CategoryId { get; set; }
        public virtual CategoryDto Category { get; set; }
    }
}