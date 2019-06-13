using System;
using System.Collections.Generic;
using System.Text;
using Blog.Logic.Entities;
using Blog.Logic.Context;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace Blog.Logic.Repository
{
   public interface IRepository<T> where T :class
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        IEnumerable<T> Get();
    }
}
