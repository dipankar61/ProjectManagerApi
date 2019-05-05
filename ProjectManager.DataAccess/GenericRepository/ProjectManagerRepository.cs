using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Data.Entity;

namespace ProjectManager.DataAccess
{
    public class ProjectManagerRepository<T> : IProjectManagerRepository<T> where T : BaseEntity
    {
        private readonly ProjectmanagerContext pmManagerContext;
        private DbSet<T> entities;
        public ProjectManagerRepository() : this(new ProjectmanagerContext()) { }

        public ProjectManagerRepository(ProjectmanagerContext pmManagerContext)
        {
            this.pmManagerContext = pmManagerContext;

        }
        private DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = pmManagerContext.Set<T>();
                return entities;

            }
        }
        public IQueryable<T> All
        {
            get
            {
                return this.Entities;
            }
        }

        public T GetById(long id)
        {
            return this.Entities.Find(id);
        }
        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public void Create(T entity)
        {
            this.Entities.Add(entity);

        }

        public void Delete(T entity)
        {
            this.Entities.Remove(entity);
        }

        public void Update(T entity)
        {
            pmManagerContext.Entry(entity).State = EntityState.Modified;
        }
        public DbSet<T> GetEntities()
        {
            return Entities;
        }
        public void SaveChange()
        {
            pmManagerContext.SaveChanges();
        }

        public void Dispose()
        {
            pmManagerContext.Dispose();
        }

        
    }
}

