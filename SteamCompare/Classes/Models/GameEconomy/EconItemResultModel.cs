using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class EconItemResultModel
    {
        public uint Status { get; set; }

        public uint NumBackpackSlots { get; set; }

        public IReadOnlyCollection<EconItemModel> Items { get; set; }
    }
}