using Countries.Helpers;
using Countries.Models;
using Countries.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Countries.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountryItemViewModel> _countries;

        public MainPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Main Page";
            LoadCountries();
        }

        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public async void LoadCountries()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();

            var connection = await _apiService.CheckConnectionAsync(url);
            if (!connection)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", "Check the internet connection", "Accept");
            }

            var response = await _apiService.GetListAsync(url, "rest", "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var _countryList = (List<CountryItemViewModel>)response.Result;

            Settings.Countries = JsonConvert.SerializeObject(_countryList);
            Countries = new ObservableCollection<CountryItemViewModel>(_countryList.Select(c => new CountryItemViewModel(_navigationService)
            {
                Alpha2Code = c.Alpha2Code,
                Alpha3Code = c.Alpha3Code,
                AltSpellings = c.AltSpellings,
                Area = c.Area,
                Borders = c.Borders,
                CallingCodes = c.CallingCodes,
                Capital = c.Capital,
                Cioc = c.Cioc,
                Currencies = c.Currencies,
                Demonym = c.Demonym,
                Flag = c.Flag,
                Gini = c.Gini,
                Languages = c.Languages,
                Latlng = c.Latlng,
                Name = c.Name,
                NativeName = c.NativeName,
                NumericCode = c.NumericCode,
                Population = c.Population,
                Region = c.Region,
                RegionalBlocs = c.RegionalBlocs,
                Subregion = c.Subregion,
                Timezones = c.Timezones,
                TopLevelDomain = c.TopLevelDomain,
                Translations = c.Translations
            }).ToList());
        }
    }
}
