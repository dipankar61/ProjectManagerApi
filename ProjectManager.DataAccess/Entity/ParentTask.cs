using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DataAccess
{
    public partial class ParentTask: BaseEntity
    {
        public ParentTask()
        {
            Task = new HashSet<Task>();
        }
        
        public int ParentId { get; set; }
        public string TaskName { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}