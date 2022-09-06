using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.SteamEconomy
{
    internal class CancelTradeOfferResult
    {
        // ?? TBD?
    }

    internal class CancelTradeOfferResultContainer
    {
        [JsonProperty("response")]
        public CancelTradeOfferResult Result { get; set; }
    }
}