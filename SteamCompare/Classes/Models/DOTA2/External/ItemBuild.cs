﻿using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class ItemBuild
    {
        public string Author { get; set; }

        public string Hero { get; set; }
        
        public string Title { get; set; }

        public IList<ItemBuildGroup> Items { get; set; }
    }
}