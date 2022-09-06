using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.GameEconomy
{
    internal class SchemaUrlResult
    {
        [JsonProperty("status")]
        public uint Status { get; set; }

        [JsonProperty("items_game_url")]
        public string ItemsGameUrl { get; set; }
    }

    internal class SchemaUrlResultContainer
    {
        [JsonProperty("result")]
        public SchemaUrlResult Result { get; set; }
    }
}