using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.Common.DTO.User
{
    public class UserCreateDTO
    {
        public int? TeamId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
    }
}