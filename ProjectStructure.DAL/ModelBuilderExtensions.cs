using System;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teams = new Team[]
            {
                new Team() {Id = 1, Name = "Mertz - Rath", CreatedAt = DateTime.Parse("2020-10-02T04:26:20.9858682+00:00")},
                new Team() {Id = 2, Name = "Osinski - Von", CreatedAt = DateTime.Parse("2021-04-16T23:05:34.2539217+00:00")},
                new Team() {Id = 3, Name = "Spencer LLC", CreatedAt = DateTime.Parse("2020-03-20T07:28:43.463555+00:00")},
                new Team() {Id = 4, Name = "Wolff Inc", CreatedAt = DateTime.Parse("2017-03-22T05:12:56.6956353+00:00")}
            };

            var users = new User[]
            {
                new User()
                {
                    Id = 1,
                    TeamId = teams[0].Id,
                    FirstName = "Rita",
                    LastName = "Murphy",
                    Email = "Rita.Murphy@gmail.com",
                    RegisteredAt = DateTime.Parse("2019-06-27T22:10:32.0396504+00:00"),
                    BirthDay = DateTime.Parse("2002-04-08T21:13:54.114525+00:00")
                },
                new User()
                {
                    Id = 2,
                    TeamId = teams[1].Id,
                    FirstName = "Courtney",
                    LastName = "McGlynn",
                    Email = "Courtney.McGlynn13@yahoo.com",
                    RegisteredAt = DateTime.Parse("2017-10-07T07:23:29.0074991+00:00"),
                    BirthDay = DateTime.Parse("2000-01-20T06:58:59.8967373+00:00")
                },
                new User()
                {
                    Id = 3,
                    TeamId = teams[2].Id,
                    FirstName = "Danny",
                    LastName = "Bernier",
                    Email = "Danny_Bernier56@hotmail.com",
                    RegisteredAt = DateTime.Parse("2017-06-19T22:57:31.8621513+00:00"),
                    BirthDay = DateTime.Parse("1966-07-14T19:56:01.9441854+00:00")
                }
            };

            var projects = new Project[]
            {
                new Project()
                {
                    Id = 1,
                    AuthorId = users[0].Id,
                    TeamId = teams[0].Id,
                    Name = "next generation",
                    Description = "Qui ex architecto qui.",
                    Deadline = DateTime.Parse("2022-02-15T07:04:40.9743781+00:00"),
                    CreatedAt = DateTime.Parse("2020-12-16T11:15:40.4826415+00:00")
                },
                new Project()
                {
                    Id = 2,
                    AuthorId = users[1].Id,
                    TeamId = teams[1].Id,
                    Name = "Data",
                    Description = "Unde ullam voluptatem eligendi architecto.",
                    Deadline = DateTime.Parse("2022-05-03T04:17:15.0718275+00:00"),
                    CreatedAt = DateTime.Parse("2020-09-19T06:56:44.0511154+00:00")
                },
                new Project()
                {
                    Id = 3,
                    AuthorId = users[2].Id,
                    TeamId = teams[2].Id,
                    Name = "Liaison pricing structure Estates",
                    Description = "Et sunt recusandae et quo dolores.",
                    Deadline = DateTime.Parse("2022-02-18T18:19:37.3005625+00:00"),
                    CreatedAt = DateTime.Parse("2021-07-05T08:51:26.6558871+00:00")
                },
                new Project()
                {
                    Id = 4,
                    AuthorId = users[2].Id,
                    TeamId = teams[2].Id,
                    Name = "Arkansas e-tailers PNG",
                    Description = "Porro reprehenderit aliquid quo enim enim.",
                    Deadline =DateTime.Parse("2022-03-09T19:41:39.9363081+00:00") ,
                    CreatedAt = DateTime.Parse("2020-12-13T04:23:25.6537877+00:00")
                }
            };

            var tasks = new Task[]
            {
                new Task()
                {
                    Id = 1,
                    ProjectId = projects[0].Id,
                    PerformerId = users[0].Id,
                    Name = "Generic Steel Towels",
                    Description = "Magni fugit ut consequatur sit voluptatem eum.",
                    State = TaskState.Created,
                    CreatedAt = DateTime.Parse("2018-09-01T12:05:42.9991778+00:00"),
                    FinishedAt = null
                },
                new Task()
                {
                    Id = 2,
                    ProjectId = projects[0].Id,
                    PerformerId = users[0].Id,
                    Name = "Lake Senior",
                    Description = "Et omnis cumque dolorem qui cupiditate aperiam.",
                    State = TaskState.Done,
                    CreatedAt = DateTime.Parse("2020-04-28T05:56:35.3695014+00:00"),
                    FinishedAt = DateTime.Parse("2021-03-30T00:51:54.3628103+00:00")
                },
                new Task()
                {
                    Id = 3,
                    ProjectId = projects[1].Id,
                    PerformerId = users[1].Id,
                    Name = "hack Estonia invoice",
                    Description =
                        "Incidunt nesciunt similique repudiandae pariatur dolorem pariatur rerum nihil voluptate.",
                    State = TaskState.Done,
                    CreatedAt = DateTime.Parse("2020-04-28T05:56:35.3695014+00:00"),
                    FinishedAt = DateTime.Parse("2021-05-30T00:51:54.3628103+00:00")
                },
                new Task()
                {
                    Id = 4,
                    ProjectId = projects[2].Id,
                    PerformerId = users[2].Id,
                    Name = "solid state maximize",
                    Description = "Sit doloribus accusantium blanditiis veniam eum.",
                    State = TaskState.Done,
                    CreatedAt = DateTime.Parse("2019-06-19T02:34:44.2059796+00:00"),
                    FinishedAt = DateTime.Parse("2021-04-14T17:21:23.8008111+00:00")
                }
            };
            modelBuilder.Entity<Team>().HasData(teams);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Task>().HasData(tasks);
        }
    }
}