using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.DAL.Entities
{
    public class Team : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
