using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class OrderPaymentIntentDto
    {   
        public string PaymentIndentId { get; set; }
        public string ClientSecret { get; set; }
    }
}