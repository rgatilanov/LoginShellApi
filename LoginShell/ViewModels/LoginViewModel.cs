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
    class LoginViewModel : BaseViewModel
    {
        private IRoutingService _navigationService;
        private readonly IIdentityService identityService;

        public LoginViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            ExecuteLogin = new Command(() => Login());
            ExecuteRegistration = new Command(() => Register());

            this.identityService = identityService ?? Locator.Current.GetService<IIdentityService>();
        }
       
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand ExecuteLogin { get; set; }
        public ICommand ExecuteRegistration { get; set; }

        //private void Login()
        //{
        //    // This is where you would probably check the login and only if valid do the navigation...
        //    //var isAuthenticated = await this.identityService.Authenticate();

        //    if (Username == "ramon" && Password == "123123")
        //    {
        //        _navigationService.NavigateTo("///main/home");
        //    }
        //    else
        //        _navigationService.NavigateTo("///main/error");
        //}

        private async void Login()
        {
            // This is where you would probably check the login and only if valid do the navigation...
            var isAuthenticated = await this.identityService.Login(Username, Password);

            User _user = (User)isAuthenticated;
            var jsonUser = JsonConvert.SerializeObject(isAuthenticated);
            if (_user != null && _user.ID > 0)
                await _navigationService.NavigateTo($"///main/home?user={jsonUser}");
            else
                await _navigationService.NavigateTo("///main/error");
        }

        private void Register()
        {
            Shell.Current.GoToAsync("//login/registration");
        }
    }
}
