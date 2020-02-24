using FutbikApp.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FutbikApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<ChatItem>> GetMessagesAsync();
        Task<bool> SendMessagesAsync(ChatItem item);
    }
}
