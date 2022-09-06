using SteamCompare.Classes.Models;
using SteamCompare.Classes.Models.SteamCommunity;
using SteamCompare.Classes.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ISteamUserStats
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GlobalAchievementPercentageModel>>> GetGlobalAchievementPercentagesForAppAsync(uint appId);

        Task<ISteamWebResponse<IReadOnlyCollection<GlobalStatModel>>> GetGlobalStatsForGameAsync(uint appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null);

        Task<ISteamWebResponse<uint>> GetNumberOfCurrentPlayersForGameAsync(uint appId);

        Task<ISteamWebResponse<PlayerAchievementResultModel>> GetPlayerAchievementsAsync(uint appId, ulong steamId, string language = "");

        Task<ISteamWebResponse<SchemaForGameResultModel>> GetSchemaForGameAsync(uint appId, string language = "");

        Task<ISteamWebResponse<UserStatsForGameResultModel>> GetUserStatsForGameAsync(ulong steamId, uint appId);
    }
}