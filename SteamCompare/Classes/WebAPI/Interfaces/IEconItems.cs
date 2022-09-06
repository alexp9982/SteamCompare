using SteamCompare.Classes.Models.GameEconomy;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface IEconItems
    {
        Task<ISteamWebResponse<EconItemResultModel>> GetPlayerItemsAsync(ulong steamId);

        Task<ISteamWebResponse<SteamCompare.Classes.WebAPI.Models.GameEconomy.SchemaItemsResultContainer>> GetSchemaItemsForTF2Async(string language = "en_us", uint? start = null);

        Task<ISteamWebResponse<SteamCompare.Classes.WebAPI.Models.GameEconomy.SchemaOverviewResultContainer>> GetSchemaOverviewForTF2Async(string language = "en_us");

        Task<ISteamWebResponse<string>> GetSchemaUrlAsync();

        Task<ISteamWebResponse<StoreMetaDataModel>> GetStoreMetaDataAsync(string language = "");

        Task<ISteamWebResponse<uint>> GetStoreStatusAsync();
    }
}