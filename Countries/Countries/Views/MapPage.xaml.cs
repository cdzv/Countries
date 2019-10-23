using System;
using Countries.Helpers;
using Countries.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Countries.Views
{
    public partial class MapPage : ContentPage
    {
        private Country _country;

        public MapPage()
        {
            InitializeComponent();
            _country = JsonConvert.DeserializeObject<Country>(Settings.Country);
            MoveMapToCountry();
        }

        private void MoveMapToCountry()
        {
            var _latitude = _country.Latlng[0];
            var _longitude = _country.Latlng[1];

            var _distance = Convert.ToInt32((_country.Area) * 0.001);

            if (_distance < 100) { _distance = 50; }


            MapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(_latitude, _longitude), Distance.FromKilometers(_distance)));
            MapView.Pins.Add(
                new Pin
                {
                    Label = _country.Name,
                    Position = new Position(_latitude, _longitude),
                    Type = PinType.Place
                });
        }
    }
}
