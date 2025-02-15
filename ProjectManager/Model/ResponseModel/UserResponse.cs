namespace ProjectManager.Model.ResponseModel
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public List<object>? Projetos { get; set; }
        public List<object>? Atividades { get; set; }
    }
}
