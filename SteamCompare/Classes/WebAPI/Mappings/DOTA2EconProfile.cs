using System.Collections.Generic;
using AutoMapper;
using SteamCompare.Classes.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Models.DOTA2;
using SteamCompare.Classes.WebAPI.Models.GameEconomy;

namespace SteamCompare.Classes.WebAPI.Mappings
{
    public class DOTA2EconProfile : Profile
    {
        public DOTA2EconProfile()
        {
            CreateMap<SteamCompare.Classes.WebAPI.Models.DOTA2.Hero, SteamCompare.Classes.Models.DOTA2.Hero>();
            CreateMap<HeroResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Hero>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamCompare.Classes.WebAPI.Models.DOTA2.Hero>, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Hero>>(src.Result != null ? src.Result.Heroes : null)
            );

            CreateMap<SteamCompare.Classes.WebAPI.Models.DOTA2.GameItem, SteamCompare.Classes.Models.DOTA2.GameItem>();
            CreateMap<GameItemResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.GameItem>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamCompare.Classes.WebAPI.Models.DOTA2.GameItem>, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.GameItem>>(src.Result != null ? src.Result.Items : null)
            );

            CreateMap<ItemIconPathResultContainer, string>().ConvertUsing(src => src.Result != null ? src.Result.Path : null);

            CreateMap<SchemaQualities, SteamCompare.Classes.Models.TF2.SchemaQualitiesModel>();
            CreateMap<SchemaOriginName, SteamCompare.Classes.Models.TF2.SchemaOriginNameModel>();
            CreateMap<Models.GameEconomy.SchemaItem, SteamCompare.Classes.Models.TF2.SchemaItemModel>();
            CreateMap<SchemaCapabilities, SteamCompare.Classes.Models.TF2.SchemaCapabilitiesModel>();
            CreateMap<SchemaStyle, SteamCompare.Classes.Models.TF2.SchemaStyleModel>();
            CreateMap<SchemaAdditionalHiddenBodygroups, SteamCompare.Classes.Models.TF2.SchemaAdditionalHiddenBodygroupsModel>();
            CreateMap<SchemaItemAttribute, SteamCompare.Classes.Models.TF2.SchemaItemAttributeModel>();
            CreateMap<SchemaPerClassLoadoutSlots, SteamCompare.Classes.Models.TF2.SchemaPerClassLoadoutSlotsModel>();
            CreateMap<SchemaTool, SteamCompare.Classes.Models.TF2.SchemaToolModel>();
            CreateMap<SchemaUsageCapabilities, SteamCompare.Classes.Models.TF2.SchemaUsageCapabilitiesModel>();
            CreateMap<SchemaAttribute, SteamCompare.Classes.Models.TF2.SchemaAttributeModel>();
            CreateMap<Models.GameEconomy.SchemaItemSet, SteamCompare.Classes.Models.TF2.SchemaItemSetModel>();
            CreateMap<SchemaItemSetAttribute, SteamCompare.Classes.Models.TF2.SchemaItemSetAttributeModel>();
            CreateMap<SchemaAttributeControlledAttachedParticle, SteamCompare.Classes.Models.TF2.SchemaAttributeControlledAttachedParticleModel>();
            CreateMap<SchemaItemLevel, SteamCompare.Classes.Models.TF2.SchemaItemLevelModel>();
            CreateMap<SchemaLevel, SteamCompare.Classes.Models.TF2.SchemaLevelModel>();
            CreateMap<SchemaKillEaterScoreType, SteamCompare.Classes.Models.TF2.SchemaKillEaterScoreTypeModel>();
            CreateMap<SchemaStringLookup, SteamCompare.Classes.Models.TF2.SchemaStringLookupModel>();
            CreateMap<SchemaString, SteamCompare.Classes.Models.TF2.SchemaStringModel>();

            // TODO: Rework the way Schema models are used for different games (TF2 / DOTA2)
            //CreateMap<SchemaQualities, SteamCompare.Classes.Models.DOTA2.SchemaQualityModel>()
            //    .ForMember(dest => dest.Name, opts => opts.Ignore())
            //    .ForMember(dest => dest.Value, opts => opts.Ignore())
            //    .ForMember(dest => dest.HexColor, opts => opts.Ignore());
            //CreateMap<SchemaResult, SteamCompare.Classes.Models.DOTA2.SchemaModel>()
            //    .ForMember(dest => dest.GameInfo, opts => opts.Ignore())
            //    .ForMember(dest => dest.Rarities, opts => opts.Ignore())
            //    .ForMember(dest => dest.Colors, opts => opts.Ignore())
            //    .ForMember(dest => dest.Prefabs, opts => opts.Ignore())
            //    .ForMember(dest => dest.ItemAutographs, opts => opts.Ignore());
            //CreateMap<SchemaResultContainer, SteamCompare.Classes.Models.DOTA2.SchemaModel>().ConvertUsing(
            //    src => Mapper.Map<SchemaResult, SteamCompare.Classes.Models.DOTA2.SchemaModel>(src.Result)
            //);

            CreateMap<SteamCompare.Classes.WebAPI.Models.DOTA2.Rarity, SteamCompare.Classes.Models.DOTA2.Rarity>();
            CreateMap<RarityResultContainer, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Rarity>>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<IList<SteamCompare.Classes.WebAPI.Models.DOTA2.Rarity>, IReadOnlyCollection<SteamCompare.Classes.Models.DOTA2.Rarity>>(src.Result != null ? src.Result.Rarities : null)
            );

            CreateMap<PrizePoolResultContainer, uint>().ConvertUsing(src => src.Result != null ? src.Result.PrizePool : default(uint));
        }
    }
}