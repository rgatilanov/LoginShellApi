﻿using LoginShell.Services.Routing;
using Splat;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginShell.ViewModels
{
    class RegistrationViewModel : BaseViewModel
    {
        private IRoutingService _navigationService;

        public RegistrationViewModel(IRoutingService navigationService = null)
        {
            _navigationService = navigationService ?? Locator.Current.GetService<IRoutingService>();
            ExecuteBack = new Command(() => Back());
            ExecuteRegistration = new Command(() => Register());
            ExecuteLoginAgain = new Command(() => LoginAgain());
        }

        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand ExecuteBack { get; set; }
        public ICommand ExecuteRegistration { get; set; }
        public ICommand ExecuteLoginAgain { get; set; }

        private async void Back()
        {
            await _navigationService.GoBack();
        }

        private async void Register()
        {
            await _navigationService.NavigateTo("//main");
        }

        private async void LoginAgain()
        {
            await _navigationService.NavigateTo("//login");
        }
    }
}
