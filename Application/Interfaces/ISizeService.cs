using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISizeService
    {
        IEnumerable<SizeDto> GetAll();
        SizeDto GetSize(int id);
         void CreateSize(SizeDto size);
         void UpdateSize(SizeDto size);
         void DeleteSize(SizeDto size);
         bool SizeExists(int id); 
    }
}