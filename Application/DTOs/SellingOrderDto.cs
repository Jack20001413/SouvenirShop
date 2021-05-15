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

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string ReceivePerson { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey(nameof(CustomerDto))]
        public int CustomerId { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public List<SellingTransactionDto> SellingTransactions { get; set; }
    }
}