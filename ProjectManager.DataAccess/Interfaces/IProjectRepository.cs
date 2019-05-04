using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    public interface IProjectRepository
    {
        void AddProject(Project proj);
        void UpdateProject(Project proj);
        IQueryable<Project> GetAllProject();
        Project GetProjectById(int Id);
    }
}
