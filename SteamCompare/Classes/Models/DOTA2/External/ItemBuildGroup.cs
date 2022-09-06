using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class ItemBuildGroup
    {
        public string Name { get; set; }
        
        public IList<string> Items { get; set; }
    }
}