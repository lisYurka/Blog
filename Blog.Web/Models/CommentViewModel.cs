using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int Author { get; set; }
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public string TheContentOfComments { get; set; }
    }
}
