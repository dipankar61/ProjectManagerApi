using System;
using System.Collections.Generic;

namespace ProjectManager.DataAccess
{
    public partial class Project: BaseEntity
    {
        public Project()
        {
            Task = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Priority { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}