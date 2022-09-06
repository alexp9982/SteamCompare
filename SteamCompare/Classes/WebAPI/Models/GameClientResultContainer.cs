using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models
{
    internal class GameClientResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("deploy_version")]
        public uint DeployVersion { get; set; }

        [JsonProperty("active_version")]
        public uint ActiveVersion { get; set; }
    }

    internal class GameClientResultContainer
    {
        [JsonProperty("result")]
        public GameClientResult Result { get; set; }
    }
}