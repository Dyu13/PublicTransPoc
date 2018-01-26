using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using PublicTransportationPoc.Core.Services;

namespace PublicTransportationPoc.Core.ViewModels
{
    public class StationsViewModel : MvxViewModel
    {
        private readonly IDataService _dataService;

        public StationsViewModel(IDataService dataService)
        {
            _dataService = dataService;

            var stationList = new List<string>
            {
                "Aldgate",
                "Beckton",
                "Becontree Heath",
                "Brent Cross",
                "Canada Water",
                "Canning Town",
                "Chingford",
                "Crystal Palace",
                "Stratford",
                "Victoria"
            };

            StationList = new MvxObservableCollection<string>(stationList);
        }

        #region Initialization

        public async void Init(Guid routeId)
        {
            if(routeId == Guid.Empty) return;

            var route = await _dataService.GetRouteById(routeId);

            Route = route.Name;
            IsFilteredByRoute = true;

            StationList = new MvxObservableCollection<string>(route.StationList);
        }

        #endregion Initialization

        #region Bound Properties

        #region PROEPRTY: Route

        private string _route;

        public string Route
        {
            get => _route;
            set
            {
                if(_route == value) return;

                _route = value;

                RaisePropertyChanged();
            }
        }

        #endregion PROPERTY: Route

        #region PROPERTY: IsFilteredByRoute

        private bool _isFilteredByRoute;

        public bool IsFilteredByRoute
        {
            get => _isFilteredByRoute;
            set
            {
                if(_isFilteredByRoute == value) return;

                _isFilteredByRoute = value;

                RaisePropertyChanged();
            }
        }

        #endregion PROPERTY: IsFilteredByRoute

        #region PROPERTY: StationList

        private MvxObservableCollection<string> _stationList;

        public MvxObservableCollection<string> StationList
        {
            get => _stationList;
            set
            {
                if (_stationList == value) return;

                _stationList = value;

                RaisePropertyChanged();
            }
        }

        #endregion PROPERTY: StationList

        #endregion Bound Properties

        public void Close()
        {
            Close(this);
        }
    }
}