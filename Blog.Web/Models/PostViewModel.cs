using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Author { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public string Content { get; set; }
        public int PhotoId { get; set; }
        public int Comment { get; set; }
    }
}
