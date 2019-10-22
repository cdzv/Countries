using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Countries.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            MapView.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(1)));
        }
    }
}
