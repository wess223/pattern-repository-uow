namespace PatternRepositoryUoW.API.Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Collaborator> Collaborators{ get; set; }
    }
}
