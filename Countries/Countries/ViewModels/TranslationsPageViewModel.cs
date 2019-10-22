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
    public class TranslationsPageViewModel : ViewModelBase
    {
        private Country _country;
        private Translations _translations;

        public TranslationsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Translations";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Translations = Country.Translations;
        }

        public Translations Translations
        {
            get => _translations;
            set => SetProperty(ref _translations, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}
