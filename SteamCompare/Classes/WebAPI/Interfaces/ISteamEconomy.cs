using SteamCompare.Classes.Models.SteamEconomy;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ISteamEconomy
    {
        Task<ISteamWebResponse<AssetClassInfoResultModel>> GetAssetClassInfoAsync(uint appId, IReadOnlyList<ulong> classIds, string language);

        Task<ISteamWebResponse<AssetPriceResultModel>> GetAssetPricesAsync(uint appId, string currency, string language);
    }
}