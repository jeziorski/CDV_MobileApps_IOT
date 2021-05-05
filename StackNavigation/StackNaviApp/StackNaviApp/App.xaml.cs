using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackNaviApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //v1

            var mainPage = new MainPage();
            var navPage = new NavigationPage(mainPage);
            MainPage = navPage;


            //v2
            //var tabbedPage = new TabbedPage();

            //tabbedPage.Children.Add(new TabPage1());
            //tabbedPage.Children.Add(new TabPage2());
            //MainPage = tabbedPage;
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
