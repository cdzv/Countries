using Countries.Resources;
using Countries.Services;
using Xamarin.Forms;

namespace Countries.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get => Resource.Accept; 
        }

        public static string Error
        {
            get => Resource.Error;
        }

        public static string ValidationInternet
        {
            get => Resource.ValidationInternet;
        }

        public static string ApplicationName
        {
            get => Resource.ApplicationName;
        }
    }
}

