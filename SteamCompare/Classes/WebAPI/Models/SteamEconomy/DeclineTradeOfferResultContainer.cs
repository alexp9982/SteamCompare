using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.SteamEconomy
{
    internal class DeclineTradeOfferResult
    {
        // ?? TBD?
    }

    internal class DeclineTradeOfferResultContainer
    {
        [JsonProperty("response")]
        public DeclineTradeOfferResult Result { get; set; }
    }
}