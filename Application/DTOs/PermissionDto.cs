using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PermissionDto
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }
    }
}