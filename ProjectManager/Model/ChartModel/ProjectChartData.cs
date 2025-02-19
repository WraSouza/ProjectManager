namespace ProjectManager.Model.ChartModel
{
    public class ProjectChartData
    {
        public ProjectChartData(string name, int qtdy)
        {
            Name = name;
            Qtdy = qtdy;
        }

        public string Name { get; private set; }
        public int Qtdy { get; set; }
    }
}
