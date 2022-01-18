using System;
using System.Collections.Generic;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.DAL
{
    public class DataContext
    {
        public List<User> Users { get; set; }
        public List<Project> Projects { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Team> Teams { get; set; }

        public DataContext()
        {
            LoadData();
        }

        private void LoadData()
        {
            #region Teams

            var team1 = new Team()
            {
                Id = 1,
                Name = "Mertz - Rath",
                CreatedAt = DateTime.Parse("2020-10-02T04:26:20.9858682+00:00")
            };
            var team2 = new Team()
            {
                Id = 2,
                Name = "Osinski - Von",
                CreatedAt = DateTime.Parse("2021-04-16T23:05:34.2539217+00:00")
            };
            Teams = new List<Team>()
            {
                team1, team2
            };
            #endregion
            #region Users

            var user1 = new User()
            {
                Id = 1,
                TeamId = team1.Id,
                Team = team1,
                FirstName = "Rita",
                LastName = "Murphy",
                Email = "Rita.Murphy@gmail.com",
                RegisteredAt = DateTime.Parse("2019-06-27T22:10:32.0396504+00:00"),
                BirthDay = DateTime.Parse("2002-04-08T21:13:54.114525+00:00")
            };
            var user2 = new User()
            {
                Id = 2,
                TeamId = team1.Id,
                Team = team1,
                FirstName = "Courtney",
                LastName = "McGlynn",
                Email = "Courtney.McGlynn13@yahoo.com",
                RegisteredAt = DateTime.Parse("2017-10-07T07:23:29.0074991+00:00"),
                BirthDay = DateTime.Parse("2000-01-20T06:58:59.8967373+00:00")
            };
            var user3 = new User()
            {
                Id = 3,
                TeamId = team2.Id,
                Team = team2,
                FirstName = "Danny",
                LastName = "Bernier",
                Email = "Danny_Bernier56@hotmail.com",
                RegisteredAt = DateTime.Parse("2017-06-19T22:57:31.8621513+00:00"),
                BirthDay = DateTime.Parse("1966-07-14T19:56:01.9441854+00:00")
            };
            Users = new List<User>()
            {
                user1, user2, user3
            };
            #endregion
            #region Projects

            var project1 = new Project()
            {
                Id = 1,
                AuthorId = user1.Id,
                Author = user1,
                TeamId = team1.Id,
                Team = team1,
                Name = "Data",
                Description = "Unde ullam voluptatem eligendi architecto.",
                Deadline = DateTime.Parse("2022-05-03T04:17:15.0718275+00:00"),
                CreatedAt = DateTime.Parse("2020-09-19T06:56:44.0511154+00:00")
            };
            var project2 = new Project()
            {
                Id = 2,
                AuthorId = user3.Id,
                Author = user3,
                TeamId = team2.Id,
                Team = team2,
                Name = "high-level",
                Description = "Ipsam eligendi alias.",
                Deadline = DateTime.Parse("2022-03-09T19:41:39.9363081+00:00"),
                CreatedAt = DateTime.Parse("2020-12-13T04:23:25.6537877+00:00")
            };
            Projects = new List<Project>()
            {
                project1, project2
            };
            #endregion
            #region Tasks

            var task1 = new Task()
            {
                Id = 1,
                ProjectId = project1.Id,
                Project = project1,
                PerformerId = user1.Id,
                Performer = user1,
                Name = "Generic Steel Towels",
                Description = "Magni fugit ut consequatur sit voluptatem eum.",
                State = TaskState.Created,
                CreatedAt = DateTime.Parse("2018-09-01T12:05:42.9991778+00:00"),
                FinishedAt = DateTime.Parse("2020-04-28T08:56:35.3695014+03:00")
            };
            var task2 = new Task()
            {
                Id = 2,
                ProjectId = project1.Id,
                Project = project1,
                PerformerId = user2.Id,
                Performer = user2,
                Name = "Lake Senior",
                Description = "Et omnis cumque dolorem qui cupiditate aperiam.",
                State = TaskState.InProgress,
                CreatedAt = DateTime.Parse("2020-04-28T05:56:35.3695014+00:00"),
                FinishedAt = null
            };
            Tasks = new List<Task>()
            {
                task1, task2
            };
            #endregion

            #region initialization collections
            user1.Tasks.Add(task1);
            user1.Projects.Add(project1);
            user2.Tasks.Add(task2);
            user3.Projects.Add(project2);
            team1.Projects.Add(project1);
            team1.Users.Add(user1);
            team1.Users.Add(user2);
            team2.Projects.Add(project2);
            team2.Users.Add(user3);
            project1.Tasks.Add(task1);
            project2.Tasks.Add(task2);
            #endregion
        }
    }
}