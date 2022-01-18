namespace Client.ViewModels
{
    public class ProjectInfo
    {
        public Project Project { get; set; }
        public Task LongestProjectTaskByDesc { get; set; }
        public Task ShortestProjectTaskByName { get; set; }
        public int TeamUsersCount { get; set; }
    }
}
