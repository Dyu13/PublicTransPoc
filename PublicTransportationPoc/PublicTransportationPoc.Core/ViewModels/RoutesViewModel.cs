using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using PublicTransportationPoc.Core.Models;
using PublicTransportationPoc.Core.Services;

namespace PublicTransportationPoc.Core.ViewModels
{
    public class RoutesViewModel : MvxViewModel
    {
        public RoutesViewModel(IDataService dataService)
        {
            _dataService = dataService;

            RouteList = new ObservableCollection<Route>();
        }

        #region Initialization

        public async void Init()
        {
            var routes = await _dataService.GetRoutes();
            if (routes == null) return;

            foreach (var route in routes)
            {
                foreach (var routeStation in route.StationList)
                {
                    route.Stations = string.IsNullOrWhiteSpace(route.Stations)
                        ? routeStation
                        : route.Stations + ", " + routeStation;
                }
            }

            RouteList = new ObservableCollection<Route>(routes);

            FinishNotificationEvent?.Invoke(this, new EventArgs());
        }

        #endregion Initialization

        #region Private Properties

        private readonly IDataService _dataService;
        private Guid _oldSelectedRouteId;

        #endregion Private Properties

        public event EventHandler<EventArgs> FinishNotificationEvent;

        #region Bound Properties

        #region PROPERTY: SelectedRoute

        private Route _selectedRoute;

        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                if (_selectedRoute == value) return;

                _selectedRoute = value;

                RaisePropertyChanged();
            }
        }

        #endregion PROPERTY: Selected Route

        #region PROPERTY: RouteList

        private ObservableCollection<Route> _routeList;

        public ObservableCollection<Route> RouteList
        {
            get => _routeList;
            set
            {
                if (_routeList == value) return;

                _routeList = value;

                RaisePropertyChanged();
            }
        }

        #endregion PROPERTY: RouteList

        #endregion Bound Properties

        #region Commands

        #region COMMAND: NavigateToStations

        private MvxCommand _navigateToStationsCommand;

        public ICommand NavigateToStationsCommand
        {
            get
            {
                _navigateToStationsCommand = _navigateToStationsCommand ?? new MvxCommand(NavigateToStations);
                return _navigateToStationsCommand;
            }
        }

        private void NavigateToStations()
        {
            ShowViewModel<StationsViewModel>();
        }

        #endregion COMMAND: NavigateToStations

        #region COMMAND: NavigateToFilteredStations

        private MvxCommand _navigateToFilteredStationsCommand;

        public ICommand NavigateToFilteredStationsCommand
        {
            get
            {
                _navigateToFilteredStationsCommand = _navigateToFilteredStationsCommand ?? new MvxCommand(NavigateToFilteredStations);
                return _navigateToFilteredStationsCommand;
            }
        }

        private async void NavigateToFilteredStations()
        {
            // Do not proceed while the value is not bound to SelectedRoute
            var i = 0;
            while (SelectedRoute == null && i < 50)
            {
                await Task.Delay(50);
                i++;
            }

            if (SelectedRoute == null) return;

            // Do not proceed while the new value is not bound to the SelectedRoute
            i = 0;
            while (SelectedRoute.RouteId == _oldSelectedRouteId && i < 50)
            {
                await Task.Delay(50);
                i++;
            }

            _oldSelectedRouteId = SelectedRoute.RouteId;

            var routeId = SelectedRoute.RouteId;
            ShowViewModel<StationsViewModel>(new { routeId });
        }

        #endregion COMMAND: NavigateToStations

        #endregion Commands
    }
}
