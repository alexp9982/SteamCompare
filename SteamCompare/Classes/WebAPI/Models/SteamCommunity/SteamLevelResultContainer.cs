﻿using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models.SteamCommunity
{
    internal class SteamLevelResult
    {
        [JsonProperty("player_level")]
        public uint PlayerLevel { get; set; }
    }

    internal class SteamLevelResultContainer
    {
        [JsonProperty("response")]
        public SteamLevelResult Result { get; set; }
    }
}