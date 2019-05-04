using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess.Repository
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly IProjectManagerRepository<Project> projRepo;
        public ProjectRepository(IProjectManagerRepository<Project> projRepo)
        {
            this.projRepo = projRepo;
        }
        public void AddProject(Project proj)
        {
            projRepo.Create(proj);
        }

        public IQueryable<Project> GetAllProject()
        {
            return projRepo.All;
        }

        public Project GetProjectById(int Id)
        {
            return projRepo.GetById(Id);
        }

        public void UpdateProject(Project proj)
        {
            projRepo.Update(proj);
        }
    }
}
