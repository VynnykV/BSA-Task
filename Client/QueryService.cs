using Client.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Task = Client.ViewModels.Task;

namespace Client
{
    public class QueryService
    {
        private readonly IConfigurationRoot _config;
        private readonly HttpClient _httpClient;
        private readonly string baseUrl;

        public QueryService(
            IConfigurationRoot config,
            HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
            baseUrl = _config.GetSection("Url").Value;
        }

        public async Task<IEnumerable<ProjectCountTasksDTO>> TasksInProjectByUserCount(int userId)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"tasksQuantityInProject/{userId}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<ProjectCountTasksDTO>>(json);
        }

        public async Task<IEnumerable<Task>> GetTasksLimitedByName(int userId, int symbolsQuantity)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"tasksLimitedByName/{userId}/{symbolsQuantity}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Task>>(json);
        }

        public async Task<IEnumerable<FinishedTask>> GetFinishedTasks(int userId, int year)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"finishedTasks/{userId}/{year}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<FinishedTask>>(json);
        }

        public async Task<IEnumerable<TeamUsersDTO>> GetOlderUsers(int age)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"olderUsers/{age}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TeamUsersDTO>>(json);
        }

        public async Task<IEnumerable<UserWithTasksDTO>> GetSortedUsersWithTasks()
        {
            var response = await _httpClient.GetAsync(baseUrl + $"sortedUsersWithTasks");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<UserWithTasksDTO>>(json);
        }

        public async Task<UserInfo> GetUserInfo(int userId)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"getUserInfo/{userId}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserInfo>(json);
        }

        public async Task<ProjectInfo> GetProjectInfo(int projectId)
        {
            var response = await _httpClient.GetAsync(baseUrl + $"getProjectInfo/{projectId}");
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProjectInfo>(json);
        }
    }
}
