﻿using AutoMapper;
using SteamCompare.Classes.Models.SteamEconomy;
using SteamCompare.Classes.WebAPI.Models.SteamEconomy;
using SteamCompare.Classes.WebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public class SteamEconomy : ISteamEconomy
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        public SteamEconomy(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamEconomy", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns some economic meta data regarding item qualities, levels, rarities, and more.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="classIds"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<AssetClassInfoResultModel>> GetAssetClassInfoAsync(uint appId, IReadOnlyList<ulong> classIds, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(classIds.Count, "class_count");

            for (int i = 0; i < classIds.Count; i++)
            {
                parameters.AddIfHasValue(classIds[i], string.Format("classid{0}", i));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<AssetClassInfoResultContainer>,
                ISteamWebResponse<AssetClassInfoResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns economic asset prices.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="currency"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<AssetPriceResultModel>> GetAssetPricesAsync(uint appId, string currency = "", string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(currency, "currency");
            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<AssetPriceResultContainer>,
                ISteamWebResponse<AssetPriceResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}