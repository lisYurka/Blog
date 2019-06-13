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
    public class CommentController : Controller
    {
        /*private IRepository<Comment> repository = null;
       /* CommentController()
        {
            repository = new BaseRepository<Comment>();
        }
        CommentController(BaseRepository<Comment> repository)
        {
            this.repository = repository;
        }
        /*public IActionResult CommentView()//////////////?????????????????????????
        {
            return View();
        }
        public void AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                repository.Create(comment);
            }
            else
                throw new Exception("Comment isn't valid!");
        }
        public void DeleteComment(int id)
        {
            var com = repository.GetById(id);
            if (com!=null)
            {
                repository.Delete(com);
            }
        }
        public void UpdateComment(Comment comment)
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
