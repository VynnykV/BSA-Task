using System;

namespace ProjectStructure.Common.DTO.User
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}