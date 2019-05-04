using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business
{
    public interface IParentTaskHandler
    {
        void AddParentTask(ParentTaskViewModel pTaskVM);
        List<ParentTaskViewModel> GetparentTasks();
    }
}
