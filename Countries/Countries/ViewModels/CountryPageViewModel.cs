using Countries.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Countries.ViewModels
{
    public class CountryPageViewModel : ViewModelBase
    {
        private Country _country;

        public CountryPageViewModel(INavigationService navigationService) : base (navigationService)
        {
            Title = "Country";
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("country"))
            {
                _country = parameters.GetValue<Country>("country");
                Title = Country.Name;
            }
        }
    }
}
