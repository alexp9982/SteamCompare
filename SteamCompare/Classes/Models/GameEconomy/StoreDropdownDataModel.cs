using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StoreDropdownDataModel
    {
        public IReadOnlyCollection<StoreDropdownModel> Dropdowns { get; set; }

        public IReadOnlyCollection<StorePrefabModel> Prefabs { get; set; }
    }
}