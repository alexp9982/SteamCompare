using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamCompare.Classes.WebAPI.Models.SteamEconomy
{
    internal class TradeOfferResult
    {
        [JsonProperty("offer")]
        public TradeOffer TradeOffer { get; set; }

        [JsonProperty("descriptions")]
        public IList<string> Descriptions { get; set; }
    }

    internal class TradeOfferResultContainer
    {
        [JsonProperty("response")]
        public TradeOfferResult Result { get; set; }
    }
}