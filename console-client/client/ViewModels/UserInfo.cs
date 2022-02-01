namespace Client.ViewModels
{
    public class UserInfo
    {
        public User User { get; set; }
        public Project LastProject { get; set; }
        public int TasksQuantityLastProject { get; set; }
        public int GeneralQuantityUnfinishedTasks { get; set; }
        public int GeneralQuantityCancelledTasks { get; set; }
        public Task LongestTaskByDuration { get; set; }
    }
}
