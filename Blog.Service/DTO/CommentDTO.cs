using System;

namespace Blog.Service.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int Author { get; set; }
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public string TheContentOfComments { get; set; }
    }
}
