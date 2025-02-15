namespace ProjectManager.Model.ProjectModel
{
    public class Project
    {

        public Project(int id,string projectName, string userName, string finishedAt, string deadLine, int idUser, bool isFinished)
        {
            Id = id;
            ProjectName = projectName;
            UserName = userName;
            FinishedAt = finishedAt;
            DeadLine = deadLine;
            IdUser = idUser;
            IsFinished = isFinished;
        }

        public int Id { get; private set; }
        public string ProjectName { get; private set; }
        public string UserName { get; private set; }
        public string FinishedAt { get; private set; }
        public string DeadLine { get; private set; }
        public int IdUser { get; private set; }
        public bool IsFinished { get; private set; }
    }
}
