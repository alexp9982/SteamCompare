using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface IGCVersion
    {
        Task<ISteamWebResponse<GameClientResultModel>> GetClientVersionAsync();

        Task<ISteamWebResponse<GameClientResultModel>> GetServerVersionAsync();
    }
}