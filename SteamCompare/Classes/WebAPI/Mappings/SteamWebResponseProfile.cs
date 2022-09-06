using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.Models.CSGO;
using SteamCompare.Classes.Models.DOTA2;
using SteamCompare.Classes.Models.GameEconomy;
using SteamCompare.Classes.Models.GameServers;
using SteamCompare.Classes.Models.SteamCommunity;
using SteamCompare.Classes.Models.SteamEconomy;
using SteamCompare.Classes.Models.SteamPlayer;
using SteamCompare.Classes.Models.TF2;
using SteamCompare.Classes.WebAPI.Models;
using SteamCompare.Classes.WebAPI.Models.CSGO;
using SteamCompare.Classes.WebAPI.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Models.GameEconomy;
using SteamCompare.Classes.WebAPI.Models.GameServers;
using SteamCompare.Classes.WebAPI.Models.SteamCommunity;
using SteamCompare.Classes.WebAPI.Models.SteamEconomy;
using SteamCompare.Classes.WebAPI.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Models.TF2;
using SteamCompare.Classes.WebAPI.Utilities;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class SteamWebResponseProfile : Profile
    {
        public SteamWebResponseProfile()
        {
            CreateSteamWebResponseMap<ServerStatusResultContainer, ServerStatusModel>();
            CreateSteamWebResponseMap<GameItemResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.GameItem>>();
            CreateSteamWebResponseMap<HeroResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Hero>>();
            CreateSteamWebResponseMap<ItemIconPathResultContainer, string>();
            CreateSteamWebResponseMap<RarityResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Rarity>>();
            CreateSteamWebResponseMap<PrizePoolResultContainer, uint>();
            CreateSteamWebResponseMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>();
            CreateSteamWebResponseMap<ProPlayerListResult, ProPlayerDetailModel>();
            CreateSteamWebResponseMap<LeagueResultContainer, IReadOnlyCollection<LeagueModel>>();
            CreateSteamWebResponseMap<LiveLeagueGameResultContainer, IReadOnlyCollection<LiveLeagueGameModel>>();
            CreateSteamWebResponseMap<MatchDetailResultContainer, MatchDetailModel>();
            CreateSteamWebResponseMap<MatchHistoryResultContainer, MatchHistoryModel>();
            CreateSteamWebResponseMap<MatchHistoryBySequenceNumberResultContainer, IReadOnlyCollection<MatchHistoryMatchModel>>();
            CreateSteamWebResponseMap<TeamInfoResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.TeamInfo>>();
            CreateSteamWebResponseMap<EconItemResultContainer, EconItemResultModel>();
            CreateSteamWebResponseMap<SchemaUrlResultContainer, string>();
            CreateSteamWebResponseMap<StoreMetaDataResultContainer, StoreMetaDataModel>();
            CreateSteamWebResponseMap<StoreStatusResultContainer, uint>();
            CreateSteamWebResponseMap<TradeHistoryResultContainer, SteamCompare.Classes.Models.SteamEconomy.TradeHistoryModel>();
            CreateSteamWebResponseMap<TradeOffersResultContainer, SteamCompare.Classes.Models.SteamEconomy.TradeOffersResultModel>();
            CreateSteamWebResponseMap<TradeOfferResultContainer, SteamCompare.Classes.Models.SteamEconomy.TradeOfferResultModel>();
            CreateSteamWebResponseMap<GameClientResultContainer, GameClientResultModel>();
            CreateSteamWebResponseMap<PlayingSharedGameResultContainer, ulong?>();
            CreateSteamWebResponseMap<CommunityBadgeProgressResultContainer, IReadOnlyCollection<BadgeQuestModel>>();
            CreateSteamWebResponseMap<BadgesResultContainer, BadgesResultModel>();
            CreateSteamWebResponseMap<SteamLevelResultContainer, uint?>();
            CreateSteamWebResponseMap<OwnedGamesResultContainer, OwnedGamesResultModel>();
            CreateSteamWebResponseMap<RecentlyPlayedGameResultContainer, RecentlyPlayedGamesResultModel>();
            CreateSteamWebResponseMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>();
            CreateSteamWebResponseMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>();
            CreateSteamWebResponseMap<AssetClassInfoResultContainer, AssetClassInfoResultModel>();
            CreateSteamWebResponseMap<AssetPriceResultContainer, AssetPriceResultModel>();
            CreateSteamWebResponseMap<SteamNewsResultContainer, SteamNewsResultModel>();
            CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>();
            CreateSteamWebResponseMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>();
            CreateSteamWebResponseMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>();
            CreateSteamWebResponseMap<PlayerSummaryResultContainer, PlayerSummaryModel>();
            CreateSteamWebResponseMap<PlayerSummaryResultContainer, IReadOnlyCollection<PlayerSummaryModel>>();
            CreateSteamWebResponseMap<FriendsListResultContainer, IReadOnlyCollection<FriendModel>>();
            CreateSteamWebResponseMap<PlayerBansContainer, IReadOnlyCollection<PlayerBansModel>>();
            CreateSteamWebResponseMap<UserGroupListResultContainer, IReadOnlyCollection<ulong>>();
            CreateSteamWebResponseMap<ResolveVanityUrlResultContainer, ulong>();
            CreateSteamWebResponseMap<GlobalAchievementPercentagesResultContainer, IReadOnlyCollection<GlobalAchievementPercentageModel>>();
            CreateSteamWebResponseMap<GlobalStatsForGameResultContainer, IReadOnlyCollection<GlobalStatModel>>();
            CreateSteamWebResponseMap<CurrentPlayersResultContainer, uint>();
            CreateSteamWebResponseMap<PlayerAchievementResultContainer, PlayerAchievementResultModel>();
            CreateSteamWebResponseMap<SchemaForGameResultContainer, SchemaForGameResultModel>();
            CreateSteamWebResponseMap<UserStatsForGameResultContainer, UserStatsForGameResultModel>();
            CreateSteamWebResponseMap<SteamServerInfo, SteamServerInfoModel>();
            CreateSteamWebResponseMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>();
            CreateSteamWebResponseMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>();
            CreateSteamWebResponseMap<GameMapsPlaytimeContainer, IEnumerable<GameMapsPlaytimeModel>>();
            CreateSteamWebResponseMap<AccountListContainer, AccountListModel>();
            CreateSteamWebResponseMap<CreateAccountContainer, CreateAccountModel>();
            CreateSteamWebResponseMap<ResetLoginTokenContainer, string>();
            CreateSteamWebResponseMap<AccountPublicInfoContainer, AccountPublicInfoModel>();
            CreateSteamWebResponseMap<QueryLoginTokenContainer, QueryLoginTokenModel>();
            CreateSteamWebResponseMap<TradeHoldDurationsResultContainer, TradeHoldDurationsResultModel>();

        }

        private SteamWebResponse<TDestination> ConstructSteamWebResponse<TSource, TDestination>(ISteamWebResponse<TSource> response, ResolutionContext context)
        {
            if (response == null)
            {
                return null;
            }

            var newResponse = new SteamWebResponse<TDestination>();

            newResponse.ContentLength = response.ContentLength;
            newResponse.ContentType = response.ContentType;
            newResponse.ContentTypeCharSet = response.ContentTypeCharSet;
            newResponse.Expires = response.Expires;
            newResponse.LastModified = response.LastModified;

            if (response.Data != null)
            {
                newResponse.Data = context.Mapper.Map<TSource, TDestination>(response.Data);
            }

            return newResponse;
        }

        private void CreateSteamWebResponseMap<TSource, TDestination>()
        {
            CreateMap<ISteamWebResponse<TSource>, ISteamWebResponse<TDestination>>()
                .ConvertUsing((src, dest, context) => ConstructSteamWebResponse<TSource, TDestination>(src, context));
        }
    }
}