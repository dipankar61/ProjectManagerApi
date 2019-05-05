﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.DataAccess;


namespace ProjectManager.Business
{
    internal class TaskHandler : ITaskHandler
    {
        private readonly ITaskRepository taskrepo;
        internal TaskHandler(ITaskRepository taskrepo)
        {
            this.taskrepo = taskrepo;
        }
        public void AddTask(TaskViewModel taskViewModel)
        {
            if(!isProjectNameExist(taskViewModel))
            {
                var task = new Task()
                {
                    TaskName = taskViewModel.TaskName,
                    StartDate = taskViewModel.StartDate,
                    EndDate = taskViewModel.EndDate,
                    ParentId = taskViewModel.ParentId,
                    Priority = taskViewModel.Priority,
                    UserId = taskViewModel.UserId,
                    ProjectId = taskViewModel.ProjectId
                };
                taskrepo.AddTask(task);
            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "task name is already exist in the system";
                throw customException;
            }

        }

        public List<TaskViewModel> GetAllTasks()
        {
            var taskList = new List<TaskViewModel>();
            taskrepo.GetAllTask().ToList().ForEach(item =>
            {
                var taskvm = new TaskViewModel()
                {
                    TaskName = item.TaskName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ParentId = item.ParentId,
                    Priority = item.Priority,
                    UserId = item.UserId,
                    ProjectId = item.ProjectId,
                    UserName = (item.User.FirstName + " " + item.User.LastName),
                    ProjectName = item.Project.ProjectName,
                    Status=item.Status
                };
                taskList.Add(taskvm);
            });
            return taskList;
        }

        public TaskViewModel GetTask(int id)
        {
            var task= taskrepo.GetTaskById(id);
            var taskvm = new TaskViewModel()
            {
                TaskName = task.TaskName,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                ParentId = task.ParentId,
                Priority = task.Priority,
                UserId = task.UserId,
                ProjectId = task.ProjectId,
                UserName = (task.User.FirstName + " " + task.User.LastName),
                ProjectName = task.Project.ProjectName
            };
            return taskvm;
        }

        public void UpdateTask(TaskViewModel taskViewModel)
        {
            
            if(!isProjectNameExist(taskViewModel))
            {
                var task = taskrepo.GetTaskById(taskViewModel.TaskId);
                task.TaskName = taskViewModel.TaskName;
                task.StartDate = taskViewModel.StartDate;
                task.EndDate = taskViewModel.EndDate;
                task.ParentId = taskViewModel.ParentId;
                task.Priority = taskViewModel.Priority;
                task.UserId = taskViewModel.UserId;
                task.ProjectId = taskViewModel.ProjectId;
                task.Status = taskViewModel.Status;
                taskrepo.UpdateTask(task);

            }
            else
            {
                var customException = new CustomException();
                customException.ExceptionMsg = "task name is already exist in the system";
                throw customException;
            }


        }
        private bool isProjectNameExist(TaskViewModel tvm)
        {
            return taskrepo.GetAllTask().Any(t => t.TaskName == tvm.TaskName);
        }
    }
}