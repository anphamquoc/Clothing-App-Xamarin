using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClothingApp
{
    public partial class App : Application
    {
        public string UserId { get; set; }
        public string CartId { get; set; }
        public string Role { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
