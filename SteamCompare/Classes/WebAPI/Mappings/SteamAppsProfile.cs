using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Models;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class SteamAppsProfile : Profile
    {
        public SteamAppsProfile()
        {
            CreateMap<SteamApp, SteamAppModel>();
            CreateMap<SteamAppListResultContainer, IReadOnlyCollection<SteamAppModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamApp>, IReadOnlyCollection<SteamAppModel>>(src.Result != null ? src.Result.Apps : null)
            );

            CreateMap<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>();
            CreateMap<SteamAppUpToDateCheckResultContainer, SteamAppUpToDateCheckModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<SteamAppUpToDateCheckResult, SteamAppUpToDateCheckModel>(src.Result)
            );
        }
    }
}