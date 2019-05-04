using System;
using System.Collections.Generic;

namespace ProjectManager.DataAccess
{
    public partial class Task: BaseEntity
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

        public virtual ParentTask Parent { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}