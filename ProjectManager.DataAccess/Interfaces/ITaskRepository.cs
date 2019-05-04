using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.DataAccess
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        IQueryable<Task> GetAllTask();
        Task GetTaskById(int id);
    }
}
