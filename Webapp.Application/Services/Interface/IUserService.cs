﻿using Webapp.Application.Dtos;

namespace Webapp.Application.Services.Interface
{
    public interface IUserService
    {
        void AddUser(InsertUserDto userDto);

        List<GetAllUser> GetAllUsers();

        GetAllUser GetById(Guid id);

        void DeleteUser(Guid id);

        void UpdateUser(Guid id, UpdateUserDto userDto);
    }
}
