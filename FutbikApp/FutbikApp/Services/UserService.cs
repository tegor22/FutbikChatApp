using DataAccess.Models;
using FutbikApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FutbikApp.Services
{
    public class UserService : IUserService
    {
        protected readonly HttpClient _client;
        protected string _apiUrl = "http://192.168.1.51:60187/User";

        public UserService()
        {
            _client = new HttpClient();
        }

        public async Task<UserDto> GetAuthDataAsync(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"{_apiUrl}/GetAuthData", data);
            if (response.IsSuccessStatusCode)
            {
                HttpContent responseContent = response.Content;
                var jsonRes = await responseContent.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserDto>(jsonRes);
                return result;
            }
            return null;
        }

        public UserDto GetFromLocal()
        {
            var json = Preferences.Get("User", null);
            if (json == null) return null;
            return JsonConvert.DeserializeObject<UserDto>(json);
        }

        public UserDto SaveToLocal(UserDto user)
        {
            var json = JsonConvert.SerializeObject(user);
            Preferences.Set("User", json);
            return user;
        }
    }
}
