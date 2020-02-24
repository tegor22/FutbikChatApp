using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FutbikApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetAuthDataAsync(UserDto user);
        UserDto GetFromLocal();
        UserDto SaveToLocal(UserDto user);
    }
}
