using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RoleDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}