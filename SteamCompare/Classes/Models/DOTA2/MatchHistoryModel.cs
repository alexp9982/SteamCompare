using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class MatchHistoryModel
    {
        public uint Status { get; set; }

        public uint NumResults { get; set; }

        public uint TotalResults { get; set; }

        public uint ResultsRemaining { get; set; }

        public IReadOnlyCollection<MatchHistoryMatchModel> Matches { get; set; }
    }
}