using SteamCompare.Classes.Models.CSGO;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ICSGOServers
    {
        Task<ISteamWebResponse<ServerStatusModel>> GetGameServerStatusAsync();
    }
}