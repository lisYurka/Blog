using System;
using Microsoft.AspNetCore.Mvc;
using Blog.Service.Interfaces;
using Blog.Web.Models;
using Blog.Service.DTO;
using System.Collections.Generic;

namespace Blog.Web.Controllers.Post
{
    public class PostController:Controller
    {
       private readonly IPostService postService;

        public PostController(IPostService service)
        {
            postService = service;
        }

        public IActionResult Post()
        {
            var posts = postService.GetPosts();
            List<PostViewModel> postViews = new List<PostViewModel>();
            foreach (var item in posts)
            {
                PostViewModel p = new PostViewModel
                {
                    Id = item.Id,
                    Category = item.Category,
                    Author = item.Author,
                    Title = item.Title,
                    Date = item.Date,
                    Like = item.Like,
                    Content = item.Content,
                    PhotoId = item.PhotoId,
                    Comment = item.Comment
                };
                postViews.Add(p);
            }
            return View(postViews);
        }
        public void AddPost(PostViewModel post)
        {
            try
            {
                var postDTO = new PostDTO { Id = post.Id, Author = post.Author, Date = post.Date, Like = post.Like };
                postService.MakePost(postDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void AddLikeToPost(int id)
        {
            try
            {
                var postDTO = postService.GetPost(id);
                postService.LikeIncrement(postDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void RemovePost(int id)
        {
            try
            {
                var postDTO = postService.GetPost(id);
                postService.RemovePost(postDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void UpdatePost(int id)
        {
            try
            {
                var postDTO = postService.GetPost(id);
                postService.UpdatePost(postDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }
    }
}
