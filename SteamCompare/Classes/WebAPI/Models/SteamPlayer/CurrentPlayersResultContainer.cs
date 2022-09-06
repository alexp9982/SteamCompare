using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.SteamPlayer
{
    internal class CurrentPlayersResult
    {
        [JsonProperty("player_count")]
        public uint PlayerCount { get; set; }

        [JsonProperty("result")]
        public uint Result { get; set; }
    }

    internal class CurrentPlayersResultContainer
    {
        [JsonProperty("response")]
        public CurrentPlayersResult Result { get; set; }
    }
}