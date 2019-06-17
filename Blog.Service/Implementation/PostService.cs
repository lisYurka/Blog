using Blog.Logic.Entities;
using Blog.Logic.Repository.Implementation;
using Blog.Service.DTO;
using Blog.Service.Infrastructure;
using Blog.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Blog.Service.Implementation
{
    public class PostService:IPostService
    {
        BaseRepository<Post> Context { get; set; }

        public PostService(BaseRepository<Post> context)
        {
            Context = context;
        }

        public List<PostDTO> GetPosts()
        {
            List<Post> posts = Context.Get();
            List<PostDTO> postsDTO=new List<PostDTO>();
            foreach(var item in posts)
            {
                PostDTO p = new PostDTO
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
                postsDTO.Add(p);
            }
            return postsDTO;            
        } 

        public void MakePost(PostDTO postDTO)
        {
            Post post = Context.GetById(postDTO.Id);
            if (post == null)
                throw new ValidationException("Пост не найден","");
            Post p = new Post
            {
                Id = post.Id,
                Category = post.Category,
                Author = post.Author,
                Title = post.Title,
                Date = post.Date,
                Like = post.Like,
                Content = post.Content,
                PhotoId = post.PhotoId,
                Comment = post.Comment
            };
            Context.Create(p);
        }

        public PostDTO GetPost(int? id)
        {
            if (id == null)
                throw new ValidationException("Пост не найден", "");
            return null;
        }

        public void LikeIncrement(PostDTO postDTO)
        {
            if (postDTO == null)
                throw new Exception("This comment is NULL!");
            else
            {
                Post post = new Post
                {
                    Id = postDTO.Id,
                    Category = postDTO.Category,
                    Author = postDTO.Author,
                    Title = postDTO.Title,
                    Date = postDTO.Date,
                    Like = postDTO.Like,
                    Content = postDTO.Content,
                    PhotoId = postDTO.PhotoId,
                    Comment = postDTO.Comment
                };
                post.Like++;
                Context.Update(post);
            }
        }

        public void RemovePost(PostDTO postDTO)
        {
            if (postDTO == null)
                throw new Exception("This post is NULL!");
            else
            {
                Post post = new Post
                {
                    Id = postDTO.Id,
                    Category = postDTO.Category,
                    Author = postDTO.Author,
                    Title = postDTO.Title,
                    Date = postDTO.Date,
                    Like = postDTO.Like,
                    Content = postDTO.Content,
                    PhotoId = postDTO.PhotoId,
                    Comment = postDTO.Comment
                };
                Context.Delete(post);
            }
        }

        public void UpdatePost(PostDTO postDTO)
        {
            if (postDTO == null)
                throw new Exception("This comment is NULL!");
            else
            {
                Post post = new Post
                {
                    Id = postDTO.Id,
                    Category = postDTO.Category,
                    Author = postDTO.Author,
                    Title = postDTO.Title,
                    Date = postDTO.Date,
                    Like = postDTO.Like,
                    Content = postDTO.Content,
                    PhotoId = postDTO.PhotoId,
                    Comment = postDTO.Comment
                };
                Context.Update(post);
            }
        }

    }
}
