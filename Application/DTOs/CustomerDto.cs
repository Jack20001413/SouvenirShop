using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CustomerDto
    {   
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public bool IsValid { get; set; }

    }
}