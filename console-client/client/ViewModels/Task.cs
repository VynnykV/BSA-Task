using System;

namespace Client.ViewModels
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                   $"name: {Name}\n" +
                   $"description: {Description}\n" +
                   $"state: {State.ToString()}\n" +
                   $"createdAt: {CreatedAt}\n" +
                   $"finishedAt: {(FinishedAt == null ? "none" : $"{FinishedAt}")}";
        }
    }
}
