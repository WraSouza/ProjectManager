namespace ProjectManager.Model.ResponseModel
{
    public class ActivitiesResponse
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public int idProject { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime FinishedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
