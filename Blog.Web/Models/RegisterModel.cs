using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Не указано мыло")]
        [Display(Name = "Почта")]
        public string Mail { get; set; }

        [Required(ErrorMessage ="Не указан логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Не введен пароль")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Ошибка ввода")]
        public string RepeatePassword { get; set; }
    }
}
