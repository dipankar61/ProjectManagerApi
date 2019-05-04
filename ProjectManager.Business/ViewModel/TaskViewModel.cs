using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Business.ViewModel
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }
        public int? Priority { get; set; }
        public int? ParentId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? ParentTaskId { get; set; }
        public string ParentTaskname { get; set; }
        
        public string UserName { get; set; }
        
        public string ProjectName { get; set; }
    }
}
