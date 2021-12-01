using Mde.CurrencyConverter.Domain;
using Mde.CurrencyConverter.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mde.CurrencyConverter.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RatesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var currencyRate = e.Item as CurrencyRate;
            var viewModel = (BindingContext as MainViewModel);
            viewModel.GotoConvert.Execute(currencyRate.Symbol);
        }

        protected override void OnAppearing()
        {
            //execute command!!!

            base.OnAppearing();
        }
    }
}
