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
    public class LanguagesPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Language> _languages;

        public LanguagesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Languages";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Languages = new ObservableCollection<Language>(Country.Languages);
        }

        public ObservableCollection<Language> Languages
        {
            get => _languages;
            set => SetProperty(ref _languages, value);
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
