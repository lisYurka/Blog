using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Logic.Entities
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public int Like { get; set; }
        public string TheContentOfComments { get; set; }
    }
}
