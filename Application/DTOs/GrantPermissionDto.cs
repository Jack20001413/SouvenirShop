using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class GrantPermissionDto
    {      
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}