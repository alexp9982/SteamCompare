using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.GameServers
{
    public class ResetLoginTokenContainer
    {
        [JsonProperty("response")]
        public ResetLoginTokenResponse Response { get; set; }
    }

    public class ResetLoginTokenResponse
    {
        [JsonProperty("login_token")]
        public string LoginToken { get; set; }
    }
}