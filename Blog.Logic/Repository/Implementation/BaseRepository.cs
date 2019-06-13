using System;
using System.Collections.Generic;
using System.Text;
using Blog.Logic.Entities;
using Blog.Logic.Context;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Blog.Logic.Repository;

namespace Blog.Service.Implementation
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private DbSet<T> dbSet;
        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = dbContext.Set<T>();
        }

       /* public BaseRepository()
        {
        }*/

        public void Create(T item)
        {
            if (item == null)
                throw new Exception("Item is null!");
            else
            {
                dbSet.Add(item);
                context.SaveChanges();
            }
        }
        public void Update(T item)
        {
            if (item == null)
                throw new Exception("Item is null!");
            else
            {
                context.Entry(item).State = EntityState.Modified;
            }

        }
        public void Delete(T item)
        {
            if (item == null)
                throw new Exception("Item is null!");
            else
            {
                dbSet.Remove(item);
                context.SaveChanges();
            }
        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }
    }
}
