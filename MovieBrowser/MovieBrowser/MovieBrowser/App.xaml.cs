using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieBrowser.Services;
using MovieBrowser.Views;
using MovieBrowser.Views.DashBoard;
using MvvmCross;
using MovieBrowser.Interface;
using MovieBrowser.Helper;

namespace MovieBrowser
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
           
            MainPage = new DashBoard();
            //MainPage = new NavigationPage(new DashBoard());
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
