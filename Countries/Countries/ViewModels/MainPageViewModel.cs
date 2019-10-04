using Countries.Models;
using Countries.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Countries.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private ObservableCollection<Country> _countries;

        public MainPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Main Page";

            LoadCountries();
        }

        public ObservableCollection<Country> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public async void LoadCountries()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();

            var response = await _apiService.GetCountries(url, "rest", "/v2/all");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var _countriesList = response.Result;

            await App.Current.MainPage.DisplayAlert("OK", response.Result.ToString(), "Accept");
        }

    }
}
