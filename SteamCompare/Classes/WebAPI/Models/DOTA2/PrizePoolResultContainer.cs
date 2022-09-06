using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.DOTA2
{
    internal class PrizePoolResult
    {
        [JsonProperty(PropertyName = "prize_pool")]
        public uint PrizePool { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public uint LeagueId { get; set; }

        public uint Status { get; set; }
    }

    internal class PrizePoolResultContainer
    {
        public PrizePoolResult Result { get; set; }
    }
}