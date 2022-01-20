using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.DAL.Entities
{
    public class User : BaseEntity
    {
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}