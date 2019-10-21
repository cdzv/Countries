using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Countries.ViewModels
{
    public class CurrenciesPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Currency> _currencies;

        public CurrenciesPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Currencies";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Currencies = new ObservableCollection<Currency>(Country.Currencies);
        }

        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set => SetProperty(ref _currencies, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            _country = JsonConvert.DeserializeObject<Country>(Settings.Country);
        }
    }
}
