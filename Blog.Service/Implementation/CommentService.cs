using System;
using Blog.Service.Interfaces;
using Blog.Service.DTO;
using Blog.Logic.Entities;
using Blog.Logic.Repository.Implementation;
using System.Collections.Generic;

namespace Blog.Service.Implementation
{
    class CommentService:ICommentService
    {
        public List<CommentDTO> GetComment()
        {
            List<Comment> comments = context.Get();
            List<CommentDTO> commentsDTO = new List<CommentDTO>();
            foreach (var item in comments)
            {
                CommentDTO c = new CommentDTO
                {
                    Id = item.Id,
                    Author = item.Author,
                    Date = item.Date,
                    Like = item.Like,
                    TheContentOfComments = item.TheContentOfComments
                };
                commentsDTO.Add(c);
            }
            return commentsDTO;
        }

        private readonly BaseRepository<Comment> context; 
        public CommentService(BaseRepository<Comment> _context)
        {
            context = _context;
        }
        public void MakeComment(CommentDTO commentmentDTO)
        {
            if (context.GetById(commentmentDTO.Id) == null)
                throw new Exception("There isn't comment with this id!");
            else
            {
                Comment comment = new Comment
                {
                    Id = commentmentDTO.Id,
                    Author= commentmentDTO.Author,
                    Date=commentmentDTO.Date,
                    Like=commentmentDTO.Like,
                    TheContentOfComments=commentmentDTO.TheContentOfComments
                };
                context.Create(comment);
            }
        }

        public CommentDTO GetCommentById(int? id) {
            if (id == null)
                throw new Exception("There isn't comment with this id!");
            Comment comment = context.GetById(id.Value);
            if(comment==null)
                throw new Exception("There isn't comment with this id!");
            else
            return new CommentDTO {Id=comment.Id, Author=comment.Author, Date=comment.Date, Like=comment.Like, TheContentOfComments= comment.TheContentOfComments };
        }

        public void LikeIncrement(CommentDTO commentmentDTO)
        {
                if(commentmentDTO == null)
                    throw new Exception("This comment is NULL!");
                else
                {
                    Comment comment = new Comment
                    {
                        Id = commentmentDTO.Id,
                        Author = commentmentDTO.Author,
                        Date = commentmentDTO.Date,
                        Like = commentmentDTO.Like,
                        TheContentOfComments = commentmentDTO.TheContentOfComments
                    };
                    comment.Like++;
                    context.Update(comment);
                }
        }

        public void RemoveComment(CommentDTO commentmentDTO)
        {
            if (commentmentDTO == null)
                throw new Exception("This comment is NULL!");
            else
            {
                Comment comment = new Comment
                {
                    Id = commentmentDTO.Id,
                    Author = commentmentDTO.Author,
                    Date = commentmentDTO.Date,
                    Like = commentmentDTO.Like,
                    TheContentOfComments = commentmentDTO.TheContentOfComments
                };
                context.Delete(comment);
            }
        }

        public void UpdateComment(CommentDTO commentmentDTO)
        {
            if (commentmentDTO == null)
                throw new Exception("This comment is NULL!");
            else
            {
                Comment comment = new Comment
                {
                    Id = commentmentDTO.Id,
                    Author = commentmentDTO.Author,
                    Date = commentmentDTO.Date,
                    Like = commentmentDTO.Like,
                    TheContentOfComments = commentmentDTO.TheContentOfComments
                };
                context.Update(comment);
            }
        }
    }
}
