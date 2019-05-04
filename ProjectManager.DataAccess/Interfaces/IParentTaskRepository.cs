using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    public interface IParentTaskRepository
    {
        void AddParentTask(ParentTask pTask);
        IQueryable<ParentTask> GetParentTasks();
    }
}
