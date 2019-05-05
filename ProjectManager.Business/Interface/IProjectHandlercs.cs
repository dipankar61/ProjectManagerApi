using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Business
{
    public interface IProjectHandler
    {
        void AddProject(ProjectViewModel pjVm);
        void UpdateProject(ProjectViewModel pjVm);
        List<ProjectViewModel> GetAllProjects();
    }
}
