using System;
using System.Collections.Generic;
using System.Text;
using Blog.Service.DTO;

namespace Blog.Service.Interfaces
{
    public interface IUserService
    {
        void MakeUser(UserDTO userDTO);
        UserDTO GetUserById(int? id);
        void RemoveUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        List<UserDTO> GetUser();
    }
}
