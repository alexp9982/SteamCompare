using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class SchemaStringLookupModel
    {
        public string TableName { get; set; }

        public IReadOnlyCollection<SchemaStringModel> Strings { get; set; }
    }
}