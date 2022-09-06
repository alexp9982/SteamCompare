using System.Collections.Generic;

namespace SteamCompare.Classes.Models.SteamPlayer
{
    public class UserStatsForGameResultModel
    {
        public ulong SteamId { get; set; }

        public string GameName { get; set; }

        public IReadOnlyCollection<UserStatModel> Stats { get; set; }

        public IReadOnlyCollection<UserStatAchievementModel> Achievements { get; set; }
    }
}