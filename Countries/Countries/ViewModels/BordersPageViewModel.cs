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
    public class BordersPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Border> _borders;

        public BordersPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Borders";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            LoadBorders();
        }

        public ObservableCollection<Border> Borders
        {
            get => _borders;
            set => SetProperty(ref _borders, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();
        }
    }
}
