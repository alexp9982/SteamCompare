﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCompare.Classes.Models.SteamStore
{
    public class StoreComingSoonModel
    {
        public uint Id { get; set; }
        
        public string Name { get; set; }
        
        public StoreItemModel[] Items { get; set; }
    }
}
