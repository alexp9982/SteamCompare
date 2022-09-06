using SteamCompare.Classes.Models.SteamCommunity;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using SteamCompare.Classes.WebAPI.Models.SteamPlayer;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface IPlayerService
    {
        Task<ISteamWebResponse<BadgesResultModel>> GetBadgesAsync(ulong steamId);

        Task<ISteamWebResponse<IReadOnlyCollection<BadgeQuestModel>>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = null);

        Task<ISteamWebResponse<OwnedGamesResultContainer>> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<uint> appIdsToFilter = null);

        Task<ISteamWebResponse<RecentlyPlayedGamesResultModel>> GetRecentlyPlayedGamesAsync(ulong steamId);

        Task<ISteamWebResponse<uint?>> GetSteamLevelAsync(ulong steamId);

        Task<ISteamWebResponse<ulong?>> IsPlayingSharedGameAsync(ulong steamId, uint appId);
    }
}