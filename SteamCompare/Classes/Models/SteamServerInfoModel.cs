using SteamCompare.Classes.Models.Utilities;
using System;

namespace SteamCompare.Classes.Models
{
    public class SteamServerInfoModel
    {
        public ulong ServerTime { get; set; }
        public string ServerTimeString { get; set; }
        public DateTime ServerTimeDateTime { get { return ServerTime.ToDateTime(); } }
    }
}