using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Service.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
    }
}
