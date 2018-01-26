using Android.App;
using Android.OS;

namespace PublicTransportationPoc.Droid.Views
{
    [Activity(Label = "Routes")]
    public class RoutesView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.RoutesView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}