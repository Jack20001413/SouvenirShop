using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class MonthCostDetailDto
    {   
        public int MonthDate { get; set; }
        public int YearDate { get; set; }
        public int Total { get; set; }
    }
}