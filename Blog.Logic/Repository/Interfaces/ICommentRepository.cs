using Blog.Logic.Entities;
using Blog.Logic.Repository;

namespace Blog.Service.Interfaces
{
    interface ICommentRepository:IRepository<Comment>
    {
        void LikeIncrement();
    }
}
