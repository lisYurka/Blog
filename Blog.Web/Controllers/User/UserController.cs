using Blog.Service.DTO;
using Blog.Service.Interfaces;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Blog.Logic;

namespace Blog.Web.Controllers
{
    public class UserController : Controller
    {
        IUserService userService;

        UserController(IUserService service)
        {
            userService = service;
        }

        public void AddUser(UserViewModel user)
        {
            try
            {
                var userDTO = new UserDTO
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    RoleId = user.RoleId,
                    Login = user.Login,
                    Mail = user.Mail,
                    Password = user.Password
                };
                userService.MakeUser(userDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        

        public void RemoveUser(int id)
        {
            try
            {
                var userDTO = userService.GetUserById(id);
                userService.RemoveUser(userDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }

        public void UpdateUser(int id)
        {
            try
            {
                var userDTO = userService.GetUserById(id);
                userService.UpdateUser(userDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error! ", ex.Message);
            }
        }
    }
}
