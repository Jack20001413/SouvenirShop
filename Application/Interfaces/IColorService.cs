using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IColorService
    {
        IEnumerable<ColorDto> GetAll();
        ColorDto GetColor(int id);
        ColorDto CreateColor(ColorDto color);
        ColorDto UpdateColor(ColorDto color);
        ColorDto DeleteColor(int id);
        bool ColorExists(int id); 
    }
}