using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ISteamApps
    {
        Task<ISteamWebResponse<IReadOnlyCollection<SteamAppModel>>> GetAppListAsync();

        Task<ISteamWebResponse<SteamAppUpToDateCheckModel>> UpToDateCheckAsync(uint appId, uint version);
    }
}