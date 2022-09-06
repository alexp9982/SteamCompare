using SteamCompare.Classes.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface IDOTA2Match
    {
        Task<ISteamWebResponse<IReadOnlyCollection<LiveLeagueGameModel>>> GetLiveLeagueGamesAsync(uint? leagueId = null, ulong? matchId = null);

        Task<ISteamWebResponse<MatchDetailModel>> GetMatchDetailsAsync(ulong matchId);

        Task<ISteamWebResponse<MatchHistoryModel>> GetMatchHistoryAsync(uint? heroId = null, uint? gameMode = null, uint? skill = null, uint? minPlayers = null, ulong? accountId = null, uint? leagueId = null, ulong? startAtMatchId = null, string matchesRequested = "", string tournamentGamesOnly = "");

        Task<ISteamWebResponse<IReadOnlyCollection<MatchHistoryMatchModel>>> GetMatchHistoryBySequenceNumberAsync(ulong? startAtMatchSequenceNumber = null, uint? matchesRequested = null);

        Task<ISteamWebResponse<IReadOnlyCollection<TeamInfo>>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = default(long?), uint? teamsRequested = null);
    }
}