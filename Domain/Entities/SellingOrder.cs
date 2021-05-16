using System;
using System.Collections.Generic;
using Domain.Entities;
using SouvenirShop.Domain.Entities.Common;

namespace SouvenirShop.Domain.Entities
{
    public class SellingOrder : EntityBase, IAggregateRoot
    {
        public DateTime InvoiceDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string ReceivePerson { get; set; }
        public string Status { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public ICollection<SellingTransaction> SellingTransactions { get; set; }
        // public string PaymentIndentId { get; set; }
        // public string ClientSecret { get; set; }

    }
}