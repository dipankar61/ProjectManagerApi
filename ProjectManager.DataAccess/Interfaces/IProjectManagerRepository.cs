﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectManager.DataAccess
{
    public interface IProjectManagerRepository<T>: IDisposable where T : BaseEntity
    {

        T GetById(Int64 id);
        T GetById(int id);
        DbSet<T> GetEntities();

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);
        IQueryable<T> All { get; }
    }
}