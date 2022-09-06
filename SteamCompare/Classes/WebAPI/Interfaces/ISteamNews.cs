using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Utilities;
using System;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ISteamNews
    {
        Task<ISteamWebResponse<SteamNewsResultModel>> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null, string feeds = null, string[] tags = null);
    }
}