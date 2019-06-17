﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Logic.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; }
        public int Author { get; set; }
        public User PostUser { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public string Content { get; set; }
        public int PhotoId { get; set; }
        public int Comment { get; set; }
        public List<Comment> PostComment { get; set; }
    }
}
