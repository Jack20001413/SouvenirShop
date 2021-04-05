using System.Collections.Generic;

namespace SouvenirShop.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public List<string> Permissions { get; set; }
    }
}