using Prism;
using Prism.Ioc;
using Countries.ViewModels;
using Countries.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Countries.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Countries
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<BordersPage, BordersPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryPage, CountryPageViewModel>();
            containerRegistry.RegisterForNavigation<CountryTabbedPage, CountryTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<CurrenciesPage, CurrenciesPageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagesPage, LanguagesPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<TranslationsPage, TranslationsPageViewModel>();
        }
    }
}
