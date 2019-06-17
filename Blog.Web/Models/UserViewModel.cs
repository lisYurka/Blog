using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
}
