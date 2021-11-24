using FreshMvvm;
using Mde.CurrencyConverter.Domain.Services;
using Mde.CurrencyConverter.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mde.CurrencyConverter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IRateService,RateService>().AsMultiInstance();

            MainPage = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
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
