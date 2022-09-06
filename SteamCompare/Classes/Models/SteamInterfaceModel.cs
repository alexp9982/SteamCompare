using System.Collections.Generic;

namespace SteamCompare.Classes.Models
{
    public class SteamInterfaceModel
    {
        public string Name { get; set; }
        
        public IReadOnlyCollection<SteamMethodModel> Methods { get; private set; }
    }
}