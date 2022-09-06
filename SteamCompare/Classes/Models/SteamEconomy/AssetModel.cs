using System.Collections.Generic;

namespace SteamCompare.Classes.Models.SteamEconomy
{
    public class AssetModel
    {
        public AssetPricesModel Prices { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public IReadOnlyCollection<AssetClassModel> Class { get; set; }

        public ulong ClassId { get; set; }

        public IReadOnlyCollection<string> Tags { get; set; }

        public IReadOnlyCollection<ulong> TagIds { get; set; }
    }
}