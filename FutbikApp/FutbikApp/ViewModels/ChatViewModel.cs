using FutbikApp.Models;
using FutbikApp.Services.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FutbikApp.ViewModels
{
    class ChatViewModel
    {
        private IMessageService _messageService => DependencyService.Get<IMessageService>();
        public ObservableCollection<ChatItem> Messages { get; set; }
        public Command LoadMessagesCommand { get; set; }

        public ChatViewModel()
        {
            Messages = new ObservableCollection<ChatItem>();
            LoadMessagesCommand = new Command(async () => await ExecuteLoadMessagesCommand());
        }

        async Task ExecuteLoadMessagesCommand()
        {
            try
            {
                Messages.Clear();
                var items = await _messageService.GetMessagesAsync();
                foreach (var item in items)
                {
                    Messages.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
