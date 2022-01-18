using System;

namespace ProjectStructure.Common.DTO.User
{
    public class UserCreateDTO
    {
        public int? TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}