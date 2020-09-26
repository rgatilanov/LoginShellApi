using System;
using System.Collections.Generic;
using System.Windows.Input;
using LoginShell.ViewModels;
using LoginShell.Views;
using Xamarin.Forms;

namespace LoginShell
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("registration", typeof(RegistrationPage));
            Routing.RegisterRoute("main/login", typeof(LoginPage));
            Routing.RegisterRoute("error", typeof(ErrorPage));
            BindingContext = this;
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}

        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("main/login"));
    }
}
