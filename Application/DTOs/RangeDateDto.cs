using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class RangeDateDto
    {   
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}