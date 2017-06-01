using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using InvolvedTodo.DAL.Context;
using InvolvedTodo.DAL.Repos.Interfaces;

namespace InvolvedTodo.DAL.Repos
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TodoDbContext Context;

        public Repository(TodoDbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}