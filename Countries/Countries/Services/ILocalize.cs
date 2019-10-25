using System.Globalization;

namespace Countries.Services
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);
    }
}
