using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.WebAPI.Models;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class SteamWebAPIUtilProfile : Profile
    {
        public SteamWebAPIUtilProfile()
        {
            CreateMap<SteamServerInfo, SteamServerInfoModel>();

            CreateMap<SteamInterface, SteamInterfaceModel>();
            CreateMap<SteamMethod, SteamMethodModel>();
            CreateMap<SteamParameter, SteamParameterModel>();
            CreateMap<SteamApiListContainer, IReadOnlyCollection<SteamInterfaceModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamInterface>, IReadOnlyCollection<SteamInterfaceModel>>(src.Result != null ? src.Result.Interfaces : null)
            );

        }
    }
}