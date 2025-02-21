namespace ProjectManager.Model.ActivityModel
{
    public class Atividade
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public int idProject { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string DeadLine { get; set; }
        public string FinishedAt { get; set; }
    }
}
