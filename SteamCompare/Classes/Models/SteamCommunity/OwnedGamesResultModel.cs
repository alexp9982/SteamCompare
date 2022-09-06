using System.Collections.Generic;

namespace SteamCompare.Classes.Models.SteamCommunity
{
    public class OwnedGamesResultModel
    {
        public uint GameCount { get; set; }

        public IReadOnlyCollection<OwnedGameModel> OwnedGames { get; set; }
    }
}