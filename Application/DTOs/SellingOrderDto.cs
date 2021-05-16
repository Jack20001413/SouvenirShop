using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.DTOs
{
    public class SellingOrderDto
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeliveryDate { get; set; }
        public string ReceivePerson { get; set; }
        public string Status { get; set; }

        [ForeignKey(nameof(CustomerDto))]
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public List<SellingTransactionDto> SellingTransactions { get; set; }
    }
}