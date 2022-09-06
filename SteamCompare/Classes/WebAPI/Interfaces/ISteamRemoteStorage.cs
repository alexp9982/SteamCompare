using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Utilities;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    using System.Collections.Generic;

    public interface ISteamRemoteStorage
    {
        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(uint itemCount, IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<IReadOnlyCollection<PublishedFileDetailsModel>>> GetPublishedFileDetailsAsync(IList<ulong> publishedFileIds);

        Task<ISteamWebResponse<PublishedFileDetailsModel>> GetPublishedFileDetailsAsync(ulong publishedFileId);

        Task<ISteamWebResponse<UGCFileDetailsModel>> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null);
    }
}