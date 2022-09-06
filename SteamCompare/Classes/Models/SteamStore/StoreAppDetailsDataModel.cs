﻿namespace SteamCompare.Classes.Models.SteamStore
{
    public class StoreAppDetailsDataModel
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public uint SteamAppId { get; set; }

        public uint RequiredAge { get; set; }

        public string ControllerSupport { get; set; }

        public bool IsFree { get; set; }

        public uint[] Dlc { get; set; }

        public string DetailedDescription { get; set; }

        public string AboutTheGame { get; set; }

        public string ShortDescription { get; set; }

        public string SupportedLanguages { get; set; }

        public string HeaderImage { get; set; }

        public string Website { get; set; }

        public dynamic PcRequirements { get; set; }

        public dynamic MacRequirements { get; set; }

        public dynamic LinuxRequirements { get; set; }

        public string[] Developers { get; set; }

        public string[] Publishers { get; set; }

        public StorePriceOverview PriceOverview { get; set; }

        public string[] Packages { get; set; }

        public StorePackageGroupModel[] PackageGroups { get; set; }

        public StorePlatformsModel Platforms { get; set; }

        public StoreMetacriticModel Metacritic { get; set; }

        public StoreCategoryModel[] Categories { get; set; }

        public StoreGenreModel[] Genres { get; set; }

        public StoreScreenshotModel[] Screenshots { get; set; }

        public StoreMovieModel[] Movies { get; set; }

        public StoreRecommendationsModel Recommendations { get; set; }

        public StoreAchievement Achievements { get; set; }

        public StoreReleaseDateModel ReleaseDate { get; set; }

        public StoreSupportInfoModel SupportInfo { get; set; }

        public string Background { get; set; }

        public StoreContentDescriptor ContentDescriptors { get; set; }
    }
}
