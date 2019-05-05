using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DataAccess
{
    public class DataAccessController
    {
        public IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }
        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository();
        }
        public ITaskRepository GetTaskRepository()
        {
            return new TaskRepository();
        }
        public IParentTaskRepository GetParentTaskRepository()
        {
            return new ParentTaskRepository();
        }

    }
}
