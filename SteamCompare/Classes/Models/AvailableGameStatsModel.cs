using System.Collections.Generic;

namespace SteamCompare.Classes.Models
{
    public class AvailableGameStatsModel
    {
        public IReadOnlyCollection<SchemaGameStatModel> Stats { get; set; }

        public IReadOnlyCollection<SchemaGameAchievementModel> Achievements { get; set; }
    }
}