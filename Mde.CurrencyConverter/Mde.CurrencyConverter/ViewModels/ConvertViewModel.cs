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
    public class ConvertViewModel : FreshBasePageModel
    {
        protected readonly IRateService rateService;
        protected CurrencyRate currencyRate;
        protected string symbol;

        public ConvertViewModel(IRateService rateService)
        {
            this.rateService = rateService;
        }

        //public async override void Init(object initData)
        //{
        //    base.Init(initData);
        //}

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Input = 100M;

            base.ViewIsAppearing(sender, e);
        }


        private string baseCurrency;
        public string BaseCurrency
        {
            get { return baseCurrency; }
            set {
                baseCurrency = value; 
                RaisePropertyChanged(); 
            }
        }

        private string quoteCurrency;
        public string QuoteCurrency
        {
            get { return quoteCurrency; }
            set { 
                quoteCurrency = value; 
                RaisePropertyChanged(); 
            }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set { 
                title = value;
                RaisePropertyChanged();
            }
        }


        private decimal input;
        public decimal Input
        {
            get { return input; }
            set { 
                input = value;
                RaisePropertyChanged();
            }
        }

        private decimal output;
        public decimal Output
        {
            get { return output; }
            set { 
                output = value;
                RaisePropertyChanged();
            }
        }

        public ICommand Refresh => new Command<string>(async (symbol) =>
        {
            currencyRate = await rateService.GetCurrencyRate(symbol);

            Title = $"Convert {currencyRate.BaseCurrency} to {currencyRate.QuoteCurrency}";
            QuoteCurrency = currencyRate.QuoteCurrency;
            BaseCurrency = currencyRate.BaseCurrency;

        });

        public ICommand Convert => new Command(() => 
        {
            
            Output = Input / currencyRate.Rate;

        });

        
    }
}
