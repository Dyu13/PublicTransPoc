using Newtonsoft.Json;

namespace PublicTransportationPoc.Core.Models
{
    public partial class Route
    {
        [JsonIgnore]
        public string Stations { get; set; }
    }
}