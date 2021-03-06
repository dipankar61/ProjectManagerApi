﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ProjectManager.UnitTest")]

namespace ProjectManager.DataAccess
{
    internal class ParentTaskRepository : IParentTaskRepository
    {
        private readonly IProjectManagerRepository<ParentTask> pTaskRepo;
        public ParentTaskRepository() : this(new ProjectManagerRepository<ParentTask>()) { }
        public ParentTaskRepository(IProjectManagerRepository<ParentTask> pTaskRepo)
        {
            this.pTaskRepo = pTaskRepo;
        }
        public void AddParentTask(ParentTask pTask)
        {
            pTaskRepo.Create(pTask);
            pTaskRepo.SaveChange();
        }

        public IQueryable<ParentTask> GetParentTasks()
        {
            return pTaskRepo.All;
        }
    }
}
