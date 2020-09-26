using Newtonsoft.Json;
using LoginShell.Models;
using LoginShell.Services.Identity;
using LoginShell.Services.Routing;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginShell.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel(Login query)
        {
            this.Login = query;
            Title = "JWT de usuario: " + this.Login.Token;
            this.Name = this.Login.Name;
        }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }

        public Login Login { get; set; }
        private void Register()
        {
            Shell.Current.GoToAsync("//login/registration");
        }
    }
}
