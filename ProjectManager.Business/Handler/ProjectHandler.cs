﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.DataAccess;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ProjectManager.UnitTest")]

namespace ProjectManager.Business
{
    internal class ProjectHandler : IProjectHandler
    {
        private readonly IProjectRepository projRepo;
       
        internal ProjectHandler(IProjectRepository projRepo)
        {
            this.projRepo = projRepo;
            
        }
        public void AddProject(ProjectViewModel pjVm)
        {
            if (!IsProjectNameExist(pjVm))
            {
                var proj = new Project()
                {
                    ProjectName = pjVm.ProjectName,
                    StartDate = pjVm.StartDate,
                    EndDate = pjVm.EndDate,
                    Priority=pjVm.Priority,
                    UserId=pjVm.UserId
                };
                projRepo.AddProject(proj);
            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "Same Project Name is already exist in the system";
                throw customException;
            }
        }

        public List<ProjectViewModel> GetAllProjects()
        {
            var listProjView = new List<ProjectViewModel>();
            projRepo.GetAllProject().ToList().ForEach(item =>
            {
                var projVM = new ProjectViewModel()
                {
                    ProjectId = item.ProjectId,
                    ProjectName = item.ProjectName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Priority = item.Priority,
                    UserId = item.UserId,
                    NoOfTask = item.Task != null ? item.Task.Count : 0,
                    NoOfTaskCompleted = item.Task != null ? item.Task.Where(t => t.Status == "Completed").Count() : 0,
                    Username = item.User != null ? (item.User.FirstName + " " + item.User.LastName) : string.Empty
                   

                };
                listProjView.Add(projVM);



            });
            return listProjView;
        }

        public void UpdateProject(ProjectViewModel pjVm)
        {
            bool isAllowEdit = false;
            var prj = projRepo.GetProjectById(pjVm.ProjectId);
            isAllowEdit = (prj.ProjectName == pjVm.ProjectName) ? true : !IsProjectNameExist(pjVm);
            if (isAllowEdit)
            {
                prj.ProjectName = pjVm.ProjectName;
                prj.StartDate = pjVm.StartDate;
                prj.EndDate = pjVm.EndDate;
                prj.Priority = pjVm.Priority;
                prj.UserId = pjVm.UserId;

                projRepo.UpdateProject(prj);
            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "Same Project Name is already exist in the system";
                throw customException;
            }
        }
        private bool IsProjectNameExist(ProjectViewModel pjVm)
        {
            return projRepo.GetAllProject().Any(p => p.ProjectName == pjVm.ProjectName);
        }
    }
}
