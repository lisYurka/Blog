using System.Collections.Generic;

namespace Blog.Logic.Repository
{
   public interface IRepository<T> where T :class
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        List<T> Get();
    }
}
