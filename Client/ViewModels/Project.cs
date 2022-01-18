using System;

namespace Client.ViewModels
{
    public class Project
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                   $"name: {Name}\n" +
                   $"description: {Description}\n" +
                   $"deadline: {Deadline}\n" +
                   $"createdAt: {CreatedAt}";
        }
    }
}
