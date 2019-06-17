using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Logic.Repository.Implementation
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;
        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = dbContext.Set<T>();
        }
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
        public List<T> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }
    }
}
