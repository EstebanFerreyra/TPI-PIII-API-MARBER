﻿using Models.DTO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUserById(int id);
        UserDTO AddUser(UserViewModel user);
        UserDTO UpdateUser(UserViewModel user);
        bool DeleteUser(int id);
    }
}
