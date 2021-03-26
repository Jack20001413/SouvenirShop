using System.Collections.Generic;

namespace SouvenirShop.Domain.Entities.Common
{
    public class Category : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}