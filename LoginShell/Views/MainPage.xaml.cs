using LoginShell.Models;
using LoginShell.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginShell.Views
{
    [QueryProperty("User", "user")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        Login _user = new Login();
        public string User
        {
            set => UserReceived = (JsonConvert.DeserializeObject<Login>(Uri.UnescapeDataString(value)));
        }
        public Login UserReceived
        {
            get => _user;
            set
            {
                _user = value;
                MainViewModel viewModel = new MainViewModel(_user);
                BindingContext = viewModel;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}