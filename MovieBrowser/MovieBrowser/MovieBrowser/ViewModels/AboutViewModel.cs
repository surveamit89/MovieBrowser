using MovieBrowser.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieBrowser.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            //Title = "About";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}