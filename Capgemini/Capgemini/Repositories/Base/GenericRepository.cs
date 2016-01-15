using Capgemini.Contexts;
using Capgemini.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DBSet { get; set; }
        protected CapgeminiDbContext Context { get; set; }

        public GenericRepository(CapgeminiDbContext context)
        {
            if(context == null)
                throw new ArgumentNullException("An instance od CapgeminiDbContext is required to use this repository.", "Context");

            Context = context;
            DBSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DBSet.Add(entity);
            }
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DBSet.Attach(entity);
                DBSet.Remove(entity);
            }
            Context.SaveChanges();
        }

        public void Detach(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public IQueryable<T> GetAll()
        {
            return DBSet;
        }

        public T GetById(int? id)
        {
            return DBSet.Find(id);
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DBSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
