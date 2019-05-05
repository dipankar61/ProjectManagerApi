using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Business
{
    public interface ITaskHandler
    {
        void AddTask(TaskViewModel taskViewModel);
        void UpdateTask(TaskViewModel taskViewModel);
        List<TaskViewModel> GetAllTasks();
        TaskViewModel GetTask(int id);
    }
}
