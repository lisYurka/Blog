using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Logic.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Mail { get; set; }
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public List<Post> Posts { get; set; }
    }
}
