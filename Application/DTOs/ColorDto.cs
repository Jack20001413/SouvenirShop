using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ColorDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}