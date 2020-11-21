using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppriceChecker
{
    public partial class App : Application
    {
        public static class Global
        {
            public static string _server;
            public static string _APIendpoint;
        }
        public App()
        {
            InitializeComponent();

            Global._server = "http://192.168.2.135:53578";
            Global._APIendpoint = Global._server;
            App.f_log("AppriceChecker Start " + Global._server);



            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new PageA());
        }

        public static void f_log(string logmessage)
        {
            //System.Console.WriteLine(logmessage);
            Debug.WriteLine(logmessage);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
