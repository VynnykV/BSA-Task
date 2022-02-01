using System;
using ProjectStructure.Common.DTO.Team;

namespace ProjectStructure.Common.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public TeamDTO Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime BirthDay { get; set; }
    }
}