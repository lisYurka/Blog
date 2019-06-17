using Blog.Logic.Entities;
using Blog.Logic.Repository.Implementation;
using Blog.Service.DTO;
using Blog.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Blog.Service.Implementation
{
    class UserService:IUserService
    {
        BaseRepository<User> Context { get; set; }
        public UserService(BaseRepository<User> context)
        {
            Context = context;
        }

        public List<UserDTO> GetUser()
        {
            List<User> users = Context.Get();
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (var item in users)
            {
                UserDTO u = new UserDTO
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Login = item.Login,
                    RoleId = item.RoleId,
                    Mail = item.Mail,
                    Password = item.Password
                };
                usersDTO.Add(u);
            }
            return usersDTO;
        }

        public void MakeUser(UserDTO userDTO)
        {
            if (Context.GetById(userDTO.Id) == null)
                throw new Exception("There isn't user with this id!");
            else
            {
                User user = new User
                {
                    Id = userDTO.Id,
                    FullName = userDTO.FullName,
                    Login = userDTO.Login,
                    RoleId = userDTO.RoleId,
                    Mail = userDTO.Mail,
                    Password = userDTO.Password
                };
                Context.Create(user);
            }
        }
        public UserDTO GetUserById(int? id)
        {
            if (id == null)
                throw new Exception("There isn't user with this id!");
            User user = Context.GetById(id.Value);
            if (user == null)
                throw new Exception("There isn't user with this id!");
            else
                return new UserDTO
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Login = user.Login,
                    Mail = user.Mail,
                    RoleId = user.RoleId,
                    Password = user.Password
                };
        }

        public void RemoveUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new Exception("This user is NULL!");
            else
            {
                User user = new User
                {
                    Id = userDTO.Id,
                    FullName = userDTO.FullName,
                    Login = userDTO.Login,
                    RoleId = userDTO.RoleId,
                    Mail = userDTO.Mail,
                    Password = userDTO.Password
                };
                Context.Delete(user);
            }
        }

        public void UpdateUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new Exception("This user is NULL!");
            else
            {
                User user = new User
                {
                    Id = userDTO.Id,
                    FullName = userDTO.FullName,
                    Login = userDTO.Login,
                    RoleId = userDTO.RoleId,
                    Mail = userDTO.Mail,
                    Password = userDTO.Password
                };
                Context.Update(user);
            }
        }
    }
}
