using FutbikApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbikApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        ChatViewModel viewModel;
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChatViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Messages.Count == 0)
                viewModel.LoadMessagesCommand.Execute(null);
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            var text = MessageTextEdit.Text;
            DisplayAlert("test", text, "No");
            MessageTextEdit.Text = "";
        }
    }
}