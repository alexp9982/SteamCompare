using SteamCompare.Classes.Models.Utilities;
using System;

namespace SteamCompare.Classes.Models
{
    public class SteamServerInfo
    {
        public ulong ServerTime { get; set; }
        public string ServerTimeString { get; set; }
        public DateTime ServerTimeDateTime { get { return ServerTime.ToDateTime(); } }
    }
}