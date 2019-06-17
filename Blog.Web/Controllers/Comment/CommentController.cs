using System;
using Microsoft.AspNetCore.Mvc;
using Blog.Service.Interfaces;
using Blog.Web.Models;
using Blog.Service.DTO;

namespace Blog.Web.Controllers
{
    public class CommentController : Controller
    {
        ICommentService commentService;

        CommentController(ICommentService service)
        {
            commentService = service;
        }

       public void AddComment(CommentViewModel comment)
       {
            try
            {
                var commentDTO = new CommentDTO { Id = comment.Id, Author = comment.Author, Date = comment.Date, Like = comment.Like };
                commentService.MakeComment(commentDTO);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Error! ",ex.Message);
            }
       }

        public void AddLikeToComment(int id)
        {        
            try
            {
                var commentDTO = commentService.GetCommentById(id);
                commentService.LikeIncrement(commentDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void RemoveComment(int id)
        {
            try
            {
                var commentDTO = commentService.GetCommentById(id);
                commentService.RemoveComment(commentDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void UpdateComment(int id)
        {
            try
            {
                var commentDTO = commentService.GetCommentById(id);
                commentService.UpdateComment(commentDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }
    }
}
