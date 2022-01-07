using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP5PM_projekt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage(); //původní kód

            //instance bindingu na ViewModel (povolí využití C# kódu v XAMLu)
            //MainPage = new MainPage(); { BindingContext = new ViewModel() };

            //přidání odkazu na vícero stránek na MainPage
            MainPage = new NavigationPage(new MainPage())
            {
                //nastavení barevného řešení NavBaru
                BarBackgroundColor = Color.DarkOrange,
                BarTextColor = Color.White,
            };
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
