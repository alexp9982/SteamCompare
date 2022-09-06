using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class SchemaItemLevelModel
    {
        public string Name { get; set; }

        public IReadOnlyCollection<SchemaLevelModel> Levels { get; set; }
    }
}