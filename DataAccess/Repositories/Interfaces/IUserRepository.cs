using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDto GetAuthData(UserDto user);
    }
}
