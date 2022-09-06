using System.Collections.Generic;

namespace SteamCompare.Classes.Models.GameEconomy
{
    public class StoreCarouselDataModel
    {
        public uint MaxDisplayBanners { get; set; }

        public IReadOnlyCollection<StoreBannerModel> Banners { get; set; }
    }
}