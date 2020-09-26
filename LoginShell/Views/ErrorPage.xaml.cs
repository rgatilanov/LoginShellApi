﻿using LoginShell.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginShell.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPage : ContentPage
    {
        public ErrorPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        internal RegistrationViewModel ViewModel { get; set; } = Locator.Current.GetService<RegistrationViewModel>();
    }
}