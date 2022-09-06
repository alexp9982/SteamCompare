using SteamCompare.Classes.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface IDOTA2Econ
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GameItem>>> GetGameItemsAsync(string language = "");

        Task<ISteamWebResponse<IReadOnlyCollection<Hero>>> GetHeroesAsync(string language = "", bool itemizedOnly = false);

        Task<ISteamWebResponse<IReadOnlyCollection<Rarity>>> GetRaritiesAsync(string language = "");

        Task<ISteamWebResponse<uint>> GetTournamentPrizePoolAsync(uint? leagueId = null);
    }
}