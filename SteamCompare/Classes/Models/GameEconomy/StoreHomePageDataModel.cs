using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StoreHomePageDataModel
    {
        public uint HomeCategoryId { get; set; }

        public IReadOnlyCollection<StorePopularItemModel> PopularItems { get; set; }
    }
}