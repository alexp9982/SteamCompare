using SteamCompare.Classes.Models.TF2;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public interface ITFItems
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GoldenWrenchModel>>> GetGoldenWrenchesAsync();
    }
}