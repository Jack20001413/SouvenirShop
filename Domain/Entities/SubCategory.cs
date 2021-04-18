using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class SubCategory : EntityBase, IAggregateRoot
    {
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}