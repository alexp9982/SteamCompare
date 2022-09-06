using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCompare.Classes.Models.TF2
{
    public class SchemaToolModel
    {
        public string Type { get; set; }
        
        public SchemaUsageCapabilitiesModel UsageCapabilities { get; set; }
        
        public string UseString { get; set; }
        
        public string Restriction { get; set; }
    }
}
