using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StoreFilterModel
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public string UrlHistoryParamName { get; set; }

        public StoreFilterAllElementModel AllElement { get; set; }

        public IReadOnlyCollection<StoreFilterElementModel> Elements { get; set; }

        public uint Count { get; set; }
    }
}