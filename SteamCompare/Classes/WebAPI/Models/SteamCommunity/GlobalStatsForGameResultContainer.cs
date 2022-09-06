using Newtonsoft.Json;
using SteamCompare.Classes.WebAPI.Utilities.JsonConverters;
using System.Collections.Generic;

namespace SteamCompare.Classes.WebAPI.Models.SteamCommunity
{
    internal class GlobalStat
    {
        public string Name { get; set; }
        public uint Total { get; set; }
    }

    internal class GlobalStatsForGameResult
    {
        [JsonConverter(typeof(GlobalStatJsonConverter))]
        [JsonProperty("globalstats")]
        public IList<GlobalStat> GlobalStats { get; set; }

        [JsonProperty("result")]
        public uint Status { get; set; }
    }

    internal class GlobalStatsForGameResultContainer
    {
        [JsonProperty("response")]
        public GlobalStatsForGameResult Result { get; set; }
    }
}