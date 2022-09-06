using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Models;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class GCVersionProfile : Profile
    {
        public GCVersionProfile()
        {
            CreateMap<GameClientResult, GameClientResultModel>();
            CreateMap<GameClientResultContainer, GameClientResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<GameClientResult, GameClientResultModel>(src.Result)
            );
        }
    }
}