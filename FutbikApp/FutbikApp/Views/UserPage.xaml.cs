using Android.Content;
using Android.Telephony;
using DataAccess.Models;
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
    public partial class UserPage : ContentPage
    {
        private UserViewModel viewModel;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public UserPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();

            if (viewModel.User == null || string.IsNullOrWhiteSpace(viewModel.User.Phone))
            {
                var number = "";
                try
                {
                    TelephonyManager mgr = Android.App.Application.Context.GetSystemService(Context.TelephonyService) as TelephonyManager;
                    number = mgr.Line1Number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (!string.IsNullOrWhiteSpace(number))
                {
                    PhoneNumberEntry.Text = number;
                }
            }
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var user = new UserDto {
                Name = NameEntry.Text,
                Phone = PhoneNumberEntry.Text                
            };
            viewModel.SaveUser(user);
            //RootPage.NavigateFromMenu(Page)
        }
    }
}