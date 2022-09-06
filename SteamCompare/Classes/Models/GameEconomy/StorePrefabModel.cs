using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StorePrefabModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<StoreConfigModel> Config { get; set; }
    }
}