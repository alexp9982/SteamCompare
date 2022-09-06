using AutoMapper;
using SteamCompare.Classes.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Models.DOTA2;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class DOTA2FantasyProfile : Profile
    {
        public DOTA2FantasyProfile()
        {
            CreateMap<PlayerOfficialInfoResult, PlayerOfficialInfoModel>();
            CreateMap<PlayerOfficialInfoResultContainer, PlayerOfficialInfoModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<PlayerOfficialInfoResult, PlayerOfficialInfoModel>(src.Result)
            );

            CreateMap<ProPlayerInfo, ProPlayerInfoModel>();
            CreateMap<ProPlayerLeaderboard, ProPlayerLeaderboardModel>();
            CreateMap<ProPlayerListResult, ProPlayerDetailModel>();
        }
    }
}