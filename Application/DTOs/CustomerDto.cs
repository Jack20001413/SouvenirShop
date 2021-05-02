using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CustomerDto
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    
        [Required]
        public string Phone { get; set; }

        [Required]
        public bool IsValid { get; set; }

    }
}