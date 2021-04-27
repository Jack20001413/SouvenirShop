using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class ImportingOrderFullDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public string Status { get; set; }

        [ForeignKey(nameof(SupplierDto))]
        public int SupplierId { get; set; }
        public virtual SupplierDto Supplier { get; set; }

        [ForeignKey(nameof(EmployeeDto))]
        public int EmployeeId { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        public IEnumerable<ImportingTransactionDto> ImportingTransactions { get; set; }

    }
}