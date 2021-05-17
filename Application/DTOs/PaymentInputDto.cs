using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class PaymentInputDto
    {   
        public int OrderId { get; set; }

    }
}