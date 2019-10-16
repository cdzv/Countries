using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Countries.ViewModels
{
    public class CountryTabbedPageViewModel : ViewModelBase
    {
        public CountryTabbedPageViewModel(
            INavigationService navigationService) : base (navigationService)
        {
            var country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            Title = country.Name;
        }
    }
}
