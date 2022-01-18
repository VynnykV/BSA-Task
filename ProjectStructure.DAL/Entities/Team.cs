using System;
using System.Collections.Generic;

namespace ProjectStructure.DAL.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
