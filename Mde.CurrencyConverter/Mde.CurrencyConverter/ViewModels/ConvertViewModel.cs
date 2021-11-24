using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mde.CurrencyConverter.ViewModels
{
    public class ConvertViewModel : FreshBasePageModel
    {
        public ConvertViewModel()
        {
            Input = 66M;
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


        public ICommand Convert => new Command(() => 
        {
            
            Output = Input / 50847.12M;

        });

        
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            Input = 100M;

            base.ViewIsAppearing(sender, e);
        }
    }
}
