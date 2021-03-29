using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class RoleFullDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<GrantPermissionDto> GrantPermissions { get; set; }
    }
}