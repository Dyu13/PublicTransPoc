using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicTransportationPoc.Api.Models;

namespace PublicTransportationPoc.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class RoutesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public RoutesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IEnumerable<Route> Get()
        {
            using (var streamReader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, "routes.json")))
            {
                var json = streamReader.ReadToEnd();
                var routes = JsonConvert.DeserializeObject<IEnumerable<Route>>(json);

                return routes;
            }
        }

        [HttpGet("{routeId}")]
        public Route Get(Guid routeId)
        {
            using (var streamReader = new StreamReader(Path.Combine(_hostingEnvironment.WebRootPath, "routes.json")))
            {
                var json = streamReader.ReadToEnd();
                var routes = JsonConvert.DeserializeObject<IEnumerable<Route>>(json);

                var routeResult = routes.FirstOrDefault(r => r.RouteId == routeId);
                return routeResult;
            }
        }
    }
}
