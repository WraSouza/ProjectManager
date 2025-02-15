namespace ProjectManager.Model.ResponseModel
{
    public class ProjectResponse
    {
        public ProjectResponse(int id,string projectName, string userName, DateTime finishedAt, DateTime deadLine, int idUser, bool isFinished)
        {
            Id = id;
            ProjectName = projectName;
            UserName = userName;
            FinishedAt = finishedAt;
            DeadLine = deadLine;
            IdUser = idUser;
            IsFinished = isFinished;
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public DateTime FinishedAt { get; set; }
        public DateTime DeadLine { get; set; }
        public int IdUser { get; set; }
        public bool IsFinished { get; set; }
    }
}
