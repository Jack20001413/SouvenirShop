using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class GrantPermission : EntityBase, IAggregateRoot
    {
        public int PermissionId { get; set; }
        public virtual Permission Permission { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}