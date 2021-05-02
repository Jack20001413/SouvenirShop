using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class CategoryFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}