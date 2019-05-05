using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    internal class TaskRepository : ITaskRepository
    {
        private readonly IProjectManagerRepository<Task> TaskRepo;
        public TaskRepository() : this(new ProjectManagerRepository<Task>()) { }
        public TaskRepository(IProjectManagerRepository<Task> TaskRepo)
        {
            this.TaskRepo = TaskRepo;
        }
        public void AddTask(Task task)
        {
            TaskRepo.Create(task);
        }

        public IQueryable<Task> GetAllTask()
        {
            return TaskRepo.All;
        }

        public void UpdateTask(Task task)
        {
            TaskRepo.Update(task);
        }
        public Task GetTaskById(int Id)
        {
            return TaskRepo.GetById(Id);
        }
    }
}
