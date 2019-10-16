using Countries.Models;
using Countries.Services;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Countries.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private ObservableCollection<CountryItemViewModel> _countries;

        public MainPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            //_navigationService = navigationService;
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

            Countries = new ObservableCollection<CountryItemViewModel>(_countryList);
        }
    }
}
