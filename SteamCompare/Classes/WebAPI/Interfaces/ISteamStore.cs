using SteamCompare.Classes.Models.SteamStore;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    internal interface ISteamStore
    {
        Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(uint appId, string cc = "");

        Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync();

        Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync();
    }
}