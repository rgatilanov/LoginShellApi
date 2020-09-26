using System.ComponentModel;
using Xamarin.Forms;
using LoginShell.ViewModels;

namespace LoginShell.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}