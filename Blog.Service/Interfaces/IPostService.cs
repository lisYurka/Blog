using Blog.Service.DTO;
using System.Collections.Generic;

namespace Blog.Service.Interfaces
{
    public interface IPostService
    {
        void MakePost(PostDTO postDTO);
        PostDTO GetPost(int? id);
        List<PostDTO> GetPosts();
        void LikeIncrement(PostDTO postDTO);
        void RemovePost(PostDTO postDTO);
        void UpdatePost(PostDTO postDTO);
    }
}
