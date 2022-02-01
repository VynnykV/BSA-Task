using System;

namespace Client.ViewModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime BirthDay { get; set; }

        public override string ToString()
        {
            return $"id: {Id}\n" +
                   $"firstname: {FirstName}\n" +
                   $"lastname: {LastName}\n" +
                   $"email: {Email}\n" +
                   $"registeredAt: {RegisteredAt}\n" +
                   $"birthday: {BirthDay}";
        }
    }
}
