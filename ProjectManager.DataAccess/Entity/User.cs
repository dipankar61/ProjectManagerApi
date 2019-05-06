using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DataAccess
{
    public partial class User: BaseEntity
    {
        public User()
        {
            Project = new HashSet<Project>();
            Task = new HashSet<Task>();
        }
       
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }

        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}