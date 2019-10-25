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

        public static string ApplicationName
        {
            get => Resource.ApplicationName;
        }

        public static string Error
        {
            get => Resource.Error;
        }

        public static string ValidationInternet
        {
            get => Resource.ValidationInternet;
        }

        public static string Search
        {
            get => Resource.Search;
        }

        public static string Capital
        {
            get => Resource.Capital;
        }

        public static string Cioc
        {
            get => Resource.Cioc;
        }

        public static string Code
        {
            get => Resource.Code;
        }

        public static string Demonym
        {
            get => Resource.Demonym;
        }

        public static string Gini
        {
            get => Resource.Gini;
        }

        public static string Name
        {
            get => Resource.Name;
        }

        public static string NativeName
        {
            get => Resource.NativeName;
        }

        public static string NumericCode
        {
            get => Resource.NumericCode;
        }

        public static string Population
        {
            get => Resource.Population;
        }

        public static string Region
        {
            get => Resource.Region;
        }

        public static string Subregion
        {
            get => Resource.Subregion;
        }

        public static string Symbol
        {
            get => Resource.Symbol;
        }
    }
}

