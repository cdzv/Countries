﻿using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace Countries.ViewModels
{
    public class CountryItemViewModel : Country
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectCountryCommand;

        public CountryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectCountryCommand => _selectCountryCommand ?? (_selectCountryCommand = new DelegateCommand(SelectCountryAsync));

        private async void SelectCountryAsync()
        {
            Settings.Country = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("CountryTabbedPage");
        }
    }
}
