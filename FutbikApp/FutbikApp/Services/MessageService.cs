using FutbikApp.Models;
using FutbikApp.Services.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FutbikApp.Services
{
    public class MessageService : IMessageService
    {
        protected readonly HttpClient _client;
        protected string _apiUrl = "http://192.168.1.51:60187/Message";

        public MessageService()
        {
            _client = new HttpClient();
        }

        public async Task<IEnumerable<ChatItem>> GetMessagesAsync()
        {
            var result = new List<ChatItem>();
            HttpResponseMessage response = await _client.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                HttpContent responseContent = response.Content;
                var json = await responseContent.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ChatItem>>(json);
            }
            return result;
        }

        public async Task<bool> SendMessagesAsync(ChatItem item)
        {
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_apiUrl, data);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
