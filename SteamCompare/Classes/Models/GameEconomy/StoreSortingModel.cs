using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StoreSortingModel
    {
        public IReadOnlyCollection<StoreSorterModel> Sorters { get; set; }

        public IReadOnlyCollection<StoreSortingPrefabModel> SortingPrefabs { get; set; }
    }
}