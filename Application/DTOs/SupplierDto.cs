using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class SupplierDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}