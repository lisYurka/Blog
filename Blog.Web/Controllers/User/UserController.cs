using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Logic.Repository;
using Blog.Logic.Entities;
using Blog.Service.Implementation;
using System.Data.Entity;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
       /* private IRepository<User> repository = null;
        /* CommentController()
         {
             repository = new BaseRepository<Comment>();
         }
        UserController(BaseRepository<User> repository)
        {
            this.repository = repository;
        }
        /*public IActionResult CommentView()//////////////?????????????????????????
        {
            return View();
        }
        public void AddUser(User comment)
        {
            if (ModelState.IsValid)
            {
                repository.Create(comment);
            }
            else
                throw new Exception("Comment isn't valid!");
        }
        public void DeleteUser(int id)
        {
            var com = repository.GetById(id);
            if (com != null)
            {
                repository.Delete(com);
            }
        }
        public void UpdateUser(User comment)
        {
            if (ModelState.IsValid)
            {
                repository.Update(comment);
            }
            else
                throw new Exception("Comment isn't valid!");
        }*/

    }
}
