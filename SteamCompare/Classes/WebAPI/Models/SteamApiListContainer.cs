using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamCompare.Classes.WebAPI.Models
{
    internal class SteamApiListResult
    {
        public IList<SteamInterface> Interfaces { get; set; }
    }

    internal class SteamApiListContainer
    {
        [JsonProperty("apilist")]
        public SteamApiListResult Result { get; set; }
    }
}