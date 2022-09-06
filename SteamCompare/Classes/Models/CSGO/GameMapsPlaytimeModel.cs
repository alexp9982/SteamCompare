using System;

namespace SteamCompare.Classes.Models.CSGO
{
    public class GameMapsPlaytimeModel
    {
        public DateTime IntervalStartTimeStamp { get; set; }
        public string MapName { get; set; }
        public float RelativePercentage { get; set; }
    }
}