using FreshMvvm;
using Mde.CurrencyConverter.Domain;
using Mde.CurrencyConverter.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.CurrencyConverter.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        protected readonly IRateService rateService;

        public MainViewModel(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            Rates = rateService.GetRates();
        }

        private IEnumerable<CurrencyRate> rates;
        public IEnumerable<CurrencyRate> Rates
        {
            get { return rates; }
            set { 
                rates = value;
                RaisePropertyChanged();
            }
        }


        public ICommand GotoConvert => new Command(ExecuteGotoConvert);

        private async void ExecuteGotoConvert()
        {
            await CoreMethods.PushPageModel<ConvertViewModel>();
        }
    }
}
