
using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.Models.SteamCommunity;
using SteamCompare.Classes.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Models;
using SteamCompare.Classes.WebAPI.Models.SteamCommunity;
using SteamCompare.Classes.WebAPI.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Utilities;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class SteamUserStatsProfile : Profile
    {
        public SteamUserStatsProfile()
        {
            CreateMap<GlobalAchievementPercentage, GlobalAchievementPercentageModel>();
            CreateMap<GlobalAchievementPercentagesResultContainer, IReadOnlyCollection<GlobalAchievementPercentageModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<GlobalAchievementPercentage>, IReadOnlyCollection<GlobalAchievementPercentageModel>>(src.Result != null ? src.Result.AchievementPercentages : null)
            );

            CreateMap<GlobalStat, GlobalStatModel>();

            CreateMap<GlobalStatsForGameResultContainer, IReadOnlyCollection<GlobalStatModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<GlobalStat>, IReadOnlyCollection<GlobalStatModel>>(src.Result != null ? src.Result.GlobalStats : null)
            );

            CreateMap<CurrentPlayersResultContainer, uint>().ConvertUsing(src =>
                src.Result != null ? src.Result.PlayerCount : default(uint)
            );

            CreateMap<PlayerAchievement, PlayerAchievementModel>()
                .ForMember(dest => dest.UnlockTime, opts => opts.MapFrom(source => source.UnlockTime.ToDateTime()));
            CreateMap<PlayerAchievementResult, PlayerAchievementResultModel>();
            CreateMap<PlayerAchievementResultContainer, PlayerAchievementResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<PlayerAchievementResult, PlayerAchievementResultModel>(src.Result)
            );

            CreateMap<AvailableGameStats, AvailableGameStatsModel>();
            CreateMap<SchemaGameAchievement, SchemaGameAchievementModel>();
            CreateMap<SchemaGameStat, SchemaGameStatModel>();
            CreateMap<SchemaForGameResult, SchemaForGameResultModel>();
            CreateMap<SchemaForGameResultContainer, SchemaForGameResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<SchemaForGameResult, SchemaForGameResultModel>(src.Result)
            );

            CreateMap<UserStatAchievement, UserStatAchievementModel>();
            CreateMap<UserStat, UserStatModel>();
            CreateMap<UserStatsForGameResult, UserStatsForGameResultModel>();
            CreateMap<UserStatsForGameResultContainer, UserStatsForGameResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<UserStatsForGameResult, UserStatsForGameResultModel>(src.Result)
            );
        }
    }
}