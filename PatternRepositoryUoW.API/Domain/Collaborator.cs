namespace PatternRepositoryUoW.API.Domain
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartamentId { get; set; }
        public Department Department { get; set; }
    }
}
