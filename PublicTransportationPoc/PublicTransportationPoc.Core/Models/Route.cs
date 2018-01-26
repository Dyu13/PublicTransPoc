using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PublicTransportationPoc.Core.Models
{
    public partial class Route
    {
        [JsonProperty("guid")]
        public Guid RouteId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stations")]
        public List<string> StationList { get; set; }
    }
}