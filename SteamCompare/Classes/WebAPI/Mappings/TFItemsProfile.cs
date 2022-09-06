using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models.TF2;
using SteamCompare.Classes.WebAPI.Models.TF2;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class TFItemsProfile : Profile
    {
        public TFItemsProfile()
        {
            CreateMap<GoldenWrench, GoldenWrenchModel>();
            CreateMap<GoldenWrenchResultContainer, IReadOnlyCollection<GoldenWrenchModel>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<GoldenWrench>, IReadOnlyCollection<GoldenWrenchModel>>(src.Result != null ? src.Result.GoldenWrenches : null)
            );

        }
    }
}