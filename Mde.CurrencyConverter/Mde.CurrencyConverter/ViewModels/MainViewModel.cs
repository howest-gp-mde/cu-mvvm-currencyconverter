using FreshMvvm;
using Mde.CurrencyConverter.Domain;
using Mde.CurrencyConverter.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public async override void Init(object initData)
        {
            base.Init(initData);

            Rates = new ObservableCollection<CurrencyRate>(await rateService.GetRates());
        }

        private ObservableCollection<CurrencyRate> rates;
        public ObservableCollection<CurrencyRate> Rates
        {
            get { return rates; }
            set { 
                rates = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ReadCrypto => new Command(async () =>
        {
           //read crypto and add to list!!
            var newRates = await rateService.DiscoverNewRates();
            foreach(var newRate in newRates)
            {
                Rates.Add(newRate);
            }
        });

        public ICommand GotoConvert => new Command<string>(ExecuteGotoConvert);

        private async void ExecuteGotoConvert(string symbol)
        {
            await CoreMethods.PushPageModel<ConvertViewModel>(
                (viewModel) =>
                {
                    viewModel.Refresh.Execute(symbol);
                }
            );
        }

    }
}
