using System.Collections.Generic;
using Newtonsoft.Json;
using SteamCompare.Classes.WebAPI.Utilities.JsonConverters;

namespace SteamCompare.Classes.WebAPI.Models.CSGO
{
    public class GameMapsPlaytime
    {
        public ulong IntervalStartTimeStamp { get; set; }
        public string MapName { get; set; }
        public float RelativePercentage { get; set; }
    }

    public class GameMapsPlaytimeResult
    {
        public IEnumerable<GameMapsPlaytime> Playtimes { get; set; }
    }

    public class GameMapsPlaytimeContainer
    {
        [JsonConverter(typeof(GameMapsPlaytimeConverter))]
        public GameMapsPlaytimeResult Result { get; set; }
    }
}