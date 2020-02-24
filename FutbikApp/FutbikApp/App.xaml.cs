using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FutbikApp.Services;
using FutbikApp.Views;
using FutbikApp.Services.Interfaces;

namespace FutbikApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<IUserService, UserService>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
