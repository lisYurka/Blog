using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Web.Models
{
    public class LoginModel
    {
        public string returnURL { get; set; }

        [Required(ErrorMessage ="Не указан логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Не введен пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Сохранить?")]
        public bool SaveLoginPassword { get; set; }
    }
}
