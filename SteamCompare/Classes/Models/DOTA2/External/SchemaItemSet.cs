using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class SchemaItemSet
    {
        public string RawName { get; set; }

        public string Name { get; set; }

        public string StoreBundleName { get; set; }

        public IList<string> Items { get; set; }
    }
}