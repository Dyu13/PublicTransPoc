using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.Visibility;
using PublicTransportationPoc.Core.ViewModels;

namespace PublicTransportationPoc.iOS.Views
{
    [MvxFromStoryboard]
    public partial class StationsView : MvxViewController
    {
        public StationsView(IntPtr handle) : base(handle)
        {
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Stations";

            var source = new MvxStandardTableViewSource(StationsTable, "TitleText .");
            StationsTable.Source = source;

            var bindingSet = this.CreateBindingSet<StationsView, StationsViewModel>();

            bindingSet.Bind(RouteText).To(vm => vm.Route);
            bindingSet.Bind(RouteText).For("Visibility").To(vm => vm.IsFilteredByRoute).WithConversion(new MvxVisibilityValueConverter());
            bindingSet.Bind(source).To(vm => vm.StationList);

            bindingSet.Apply();

            StationsTable.ReloadData();
        }

        #endregion
    }
}