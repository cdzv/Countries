using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Countries.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            var _country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            MapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(_country.Latlng[0], _country.Latlng[1]), Distance.FromKilometers(800)));
        }
    }
}
