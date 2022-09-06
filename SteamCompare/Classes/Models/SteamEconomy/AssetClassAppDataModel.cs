using System.Collections.Generic;

namespace SteamCompare.Classes.Models.SteamEconomy
{
    public class AssetClassAppDataModel
    {
        public uint DefIndex { get; set; }

        public string Quality { get; set; }

        public string Slot { get; set; }

        public IReadOnlyCollection<AssetClassAppDataFilterModel> FilterData { get; set; }

        public IReadOnlyCollection<ulong> PlayerClassIds { get; set; }

        public string HighlightColor { get; set; }
    }
}