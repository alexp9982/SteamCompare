using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Models;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class SteamNewsProfile : Profile
    {
        public SteamNewsProfile()
        {
            CreateMap<NewsItem, NewsItemModel>();
            CreateMap<SteamNewsResult, SteamNewsResultModel>();
            CreateMap<SteamNewsResultContainer, SteamNewsResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<SteamNewsResult, SteamNewsResultModel>(src.Result)
            );
        }
    }
}