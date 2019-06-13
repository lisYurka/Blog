using System;
using System.Collections.Generic;
using System.Text;
using Blog.Logic.Entities;
using Blog.Logic.Context;
using Blog.Logic.Repository;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace Blog.Service.Interfaces
{
    interface ICommentRepository:IRepository<Comment>
    {
        void LikeIncrement();
    }
}
