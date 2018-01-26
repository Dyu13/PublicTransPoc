using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PublicTransportationPoc.Core.Models;

namespace PublicTransportationPoc.Core.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Route>> GetRoutes();

        Task<Route> GetRouteById(Guid routeId);
    }
}