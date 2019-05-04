using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.DataAccess;

namespace ProjectManager.Business.Handler
{
    internal class ParentTaskhandler : IParentTaskHandler
    {
        private readonly IParentTaskRepository pTaskrepo;
        internal ParentTaskhandler(IParentTaskRepository pTaskrepo)
        {
            this.pTaskrepo = pTaskrepo;
        }
        public void AddParentTask(ParentTaskViewModel pTaskVM)
        {
            if(!IsParentTaskNameExist(pTaskVM.TaskName))
            {
                var pTask = new ParentTask()
                {
                    TaskName = pTaskVM.TaskName
                };
                pTaskrepo.AddParentTask(pTask);
            }
        }

        public List<ParentTaskViewModel> GetparentTasks()
        {
            var parenttaskList = new List<ParentTaskViewModel>();
            pTaskrepo.GetParentTasks().ToList().ForEach(item =>
             {
                 var viewModel = new ParentTaskViewModel()
                 {
                     ParentId = item.ParentId,
                     TaskName = item.TaskName
                 };
                 parenttaskList.Add(viewModel);

             }
            );
            return parenttaskList;
        }
        private bool IsParentTaskNameExist(string pTaskName)
        {
            return pTaskrepo.GetParentTasks().Any(t => t.TaskName == pTaskName);
        }
    }
}
