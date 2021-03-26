using System;
using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class ImportingOrder : EntityBase, IAggregateRoot
    {
        public DateTime InvoiceDate { get; set; }
        public int Total { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<ImportingTransaction> Transactions { get; set; }
    }
}