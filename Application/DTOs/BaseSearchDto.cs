using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SouvenirShop.Domain.Entities;

namespace Application.DTOs
{
    public class BaseSearchDto<T>
    {
        public int currentPage { get; set; }
        public int recordOfPage { get; set; }
        public long totalRecords { get; set; }
        public bool sortAsc { get; set; }
        public string sortBy { get; set; }
        public string createdDateSort { get; set; }
        public int pagingRange { get; set; }
        public List<T> result { get; set; }

        public static implicit operator BaseSearchDto<T>(BaseSearchDto<ColorDto> v)
        {
            throw new NotImplementedException();
        }
    }
}