using SteamCompare.Classes.Models.DOTA2;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class SchemaToolModel
    {
        public string Type { get; set; }

        public SchemaUsageCapabilitiesModel UsageCapabilities { get; set; }

        public SchemaItemToolUsage Usage { get; set; }

        public string UseString { get; set; }

        public string Restriction { get; set; }
    }
}