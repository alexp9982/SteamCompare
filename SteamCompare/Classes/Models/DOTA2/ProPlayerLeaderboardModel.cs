using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class ProPlayerLeaderboardModel
    {
        public uint Division { get; set; }

        public IReadOnlyCollection<uint> AccountIds { get; set; }
    }
}