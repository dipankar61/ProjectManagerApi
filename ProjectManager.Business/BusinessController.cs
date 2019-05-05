using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.DataAccess;

namespace ProjectManager.Business
{
    public class BusinessController
    {
        private readonly DataAccessController dataAccessController;
        public BusinessController()
        {
            dataAccessController = new DataAccessController();
        }
        public IUserHandler GetUserHandler()
        {
            var userRepo = dataAccessController.GetUserRepository();
            return new UserHandler(userRepo);

        }
        public IProjectHandler GetProjectHandler()
        {
            var ProjRepo = dataAccessController.GetProjectRepository();
            return new ProjectHandler(ProjRepo);
        }
        public ITaskHandler GetTaskHandler()
        {
            var taskRepo = dataAccessController.GetTaskRepository();
            return new TaskHandler(taskRepo);

        }
        public IParentTaskHandler GetParentTaskHandler()
        {
            var pTaskRepo = dataAccessController.GetParentTaskRepository();
            return new ParentTaskhandler(pTaskRepo);
        }
    }
}
