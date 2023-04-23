﻿namespace PatternRepositoryUoW.API.Domain
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
