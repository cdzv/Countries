using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Countries.ViewModels
{
    public class BordersPageViewModel : ViewModelBase
    {
        private Country _country;
        private ObservableCollection<Border> _borders;
        private List<Country> _countries;

        public BordersPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Borders";
            Country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Countries = JsonConvert.DeserializeObject<List<Country>>(Settings.Countries);
            LoadBorders();
        }

        public ObservableCollection<Border> Borders
        {
            get => _borders;
            set => SetProperty(ref _borders, value);
        }

        public List<Country> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }

        public Country Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();

            foreach (var border in Country.Borders)
            {
                var country = Countries.Where(c => c.Alpha3Code == border).FirstOrDefault();

                if (country != null)
                {
                    Borders.Add(new Border
                    {
                        Code = country.Alpha3Code,
                        Name = country.Name,
                    });
                }
            }
        }
    }
}
