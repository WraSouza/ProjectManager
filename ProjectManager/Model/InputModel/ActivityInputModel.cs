namespace ProjectManager.Model.InputModel
{
    public class ActivityInputModel
    {
        public ActivityInputModel(string activityName, int idUser, int idProject, DateTime deadLine)
        {
            this.activityName = activityName;
            this.idUser = idUser;
            this.idProject = idProject;
            this.deadLine = deadLine;
        }

        public string activityName { get; private set; }
        public int idUser { get; private set; }
        public int idProject { get; private set; }
        public DateTime deadLine { get; private set; }
    }
}
