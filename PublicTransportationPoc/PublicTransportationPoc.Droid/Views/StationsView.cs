using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Plugins.Visibility;
using PublicTransportationPoc.Core.ViewModels;

namespace PublicTransportationPoc.Droid.Views
{
    [Activity(Label = "Stations")]
    public class StationsView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.StationsView;

        protected StationsViewModel StationViewModel => ViewModel as StationsViewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var bindingSet = this.CreateBindingSet<StationsView, StationsViewModel>();

            var routeText = FindViewById<TextView>(Resource.Id.route_text);
            bindingSet.Bind(routeText)
                .For(view => view.Text)
                .To(viewModel => viewModel.Route)
                .OneWay();
            bindingSet.Bind(routeText)
                .For(view => view.Visibility)
                .To(viewModel => viewModel.IsFilteredByRoute)
                .OneWay()
                .WithConversion(new MvxVisibilityValueConverter());

            bindingSet.Apply();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    StationViewModel.Close();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}