using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISizeService
    {
        IEnumerable<SizeDto> GetAll();
        SizeDto GetSize(int id);
        SizeDto CreateSize(SizeDto sizeDto);
        SizeDto UpdateSize(SizeDto sizeDto);
        SizeDto DeleteSize(int id);
         bool SizeExists(int id); 
    }
}