namespace ProjectManager.Model.InputModel
{
    public class ProjectInputModel
    {
        public ProjectInputModel(string projectName, DateTime deadLine, int idUser)
        {
            ProjectName = projectName;
            DeadLine = deadLine;
            IdUser = idUser;
        }

        public string ProjectName { get; private set; }
        public DateTime DeadLine { get; private set; }
        public int IdUser { get; private set; }
    }
}
