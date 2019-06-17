using Blog.Service.DTO;
using System.Collections.Generic;

namespace Blog.Service.Interfaces
{
    public interface ICommentService
    {
        void MakeComment(CommentDTO commetnDTO);
        CommentDTO GetCommentById(int? id);
        void LikeIncrement(CommentDTO commentDTO);
        void RemoveComment(CommentDTO commentDTO);
        void UpdateComment(CommentDTO commentDTO);
        List<CommentDTO> GetComment();
    }
}
