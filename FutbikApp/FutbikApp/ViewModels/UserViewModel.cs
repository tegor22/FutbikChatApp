using DataAccess.Models;
using FutbikApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FutbikApp.ViewModels
{
    public class UserViewModel
    {
        private IUserService _userService => DependencyService.Get<IUserService>();

        public UserDto User { get; set; }

        public UserViewModel()
        {
            User = _userService.GetFromLocal();
        }

        public UserDto SaveUser(UserDto dto)
        {
            return _userService.SaveToLocal(dto);
        }
    }
}
