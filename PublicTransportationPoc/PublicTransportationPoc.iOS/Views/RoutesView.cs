using System;
using System.Threading.Tasks;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using PublicTransportationPoc.Core.ViewModels;

namespace PublicTransportationPoc.iOS.Views
{
    [MvxFromStoryboard]
    public partial class RoutesView : MvxViewController
    {
        protected RoutesViewModel RoutesViewModel => ViewModel as RoutesViewModel;

        public RoutesView(IntPtr handle) : base(handle)
        {
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.Title = "Routes";

            var source = new MvxSimpleTableViewSource(RoutesTable, RouteCell.Key, RouteCell.Key);
            RoutesTable.Source = source;

            var bindingSet = this.CreateBindingSet<RoutesView, RoutesViewModel>();

            bindingSet.Bind(StationsButton).To(vm => vm.NavigateToStationsCommand);
            bindingSet.Bind(source).To(vm => vm.RouteList);
            bindingSet.Bind(source).For(s => s.SelectedItem).To(vm => vm.SelectedRoute);
            bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.NavigateToFilteredStationsCommand);

            bindingSet.Apply();

            RoutesTable.ReloadData();

            RoutesViewModel.FinishNotificationEvent += OnFinishFetchData;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            RoutesViewModel.FinishNotificationEvent -= OnFinishFetchData;
        }

        #endregion

        private async void OnFinishFetchData(object sender, EventArgs eventArgs)
        {
            await Task.Delay(250);

            RoutesTable.ReloadData();
        }
    }
}