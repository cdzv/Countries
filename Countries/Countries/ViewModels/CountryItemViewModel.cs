using Countries.Models;
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
            var parameters = new NavigationParameters
            {
                {"country", this }
            };

            await _navigationService.NavigateAsync("CountryPage", parameters);
        }
    }
}
