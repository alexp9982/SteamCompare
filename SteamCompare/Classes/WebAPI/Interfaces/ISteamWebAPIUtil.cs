using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ISteamWebAPIUtil
    {
        Task<ISteamWebResponse<SteamServerInfoModel>> GetServerInfoAsync();

        Task<ISteamWebResponse<IReadOnlyCollection<SteamInterfaceModel>>> GetSupportedAPIListAsync();
    }
}