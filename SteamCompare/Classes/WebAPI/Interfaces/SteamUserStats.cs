using AutoMapper;
using SteamCompare.Classes.Models;
using SteamCompare.Classes.Models.SteamCommunity;
using SteamCompare.Classes.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Models;
using SteamCompare.Classes.WebAPI.Models.SteamCommunity;
using SteamCompare.Classes.WebAPI.Models.SteamPlayer;
using SteamCompare.Classes.WebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public class SteamUserStats : ISteamUserStats
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamUserStats(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamUserStats", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of global achievement progress for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GlobalAchievementPercentageModel>>> GetGlobalAchievementPercentagesForAppAsync(uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "gameid");

            var steamWebResponse = await steamWebInterface.GetAsync<GlobalAchievementPercentagesResultContainer>("GetGlobalAchievementPercentagesForApp", 2, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<GlobalAchievementPercentagesResultContainer>,
                ISteamWebResponse<IReadOnlyCollection<GlobalAchievementPercentageModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of global statistics for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="statNames"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GlobalStatModel>>> GetGlobalStatsForGameAsync(uint appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null)
        {
            ulong? startDateUnixTimeStamp = null;
            ulong? endDateUnixTimeStamp = null;

            if (startDate.HasValue)
            {
                startDateUnixTimeStamp = startDate.Value.ToUnixTimeStamp();
            }

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(statNames.Count, "count");
            parameters.AddIfHasValue(startDateUnixTimeStamp, "startdate");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");

            for (int i = 0; i < statNames.Count; i++)
            {
                parameters.AddIfHasValue(statNames[i], string.Format("name[{0}]", i));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GlobalStatsForGameResultContainer>("GetGlobalStatsForGame", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<GlobalStatsForGameResultContainer>,
                ISteamWebResponse<IReadOnlyCollection<GlobalStatModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the number of current players on Steam for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint>> GetNumberOfCurrentPlayersForGameAsync(uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");

            var steamWebResponse = await steamWebInterface.GetAsync<CurrentPlayersResultContainer>("GetNumberOfCurrentPlayers", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<CurrentPlayersResultContainer>,
                ISteamWebResponse<uint>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a specific Steam User's achievements for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="steamId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<PlayerAchievementResultModel>> GetPlayerAchievementsAsync(uint appId, ulong steamId, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(language, "l");

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerAchievementResultContainer>("GetPlayerAchievements", 1, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<PlayerAchievementResultContainer>,
                ISteamWebResponse<PlayerAchievementResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns game version, achievements, and stats overviews for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaForGameResultModel>> GetSchemaForGameAsync(uint appId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "l");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaForGameResultContainer>("GetSchemaForGame", 2, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<SchemaForGameResultContainer>,
                ISteamWebResponse<SchemaForGameResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a specific Steam User's achievement and stats for a specific Steam App.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<UserStatsForGameResultModel>> GetUserStatsForGameAsync(ulong steamId, uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(appId, "appid");

            var steamWebResponse = await steamWebInterface.GetAsync<UserStatsForGameResultContainer>("GetUserStatsForGame", 2, parameters);

            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<UserStatsForGameResultContainer>,
                ISteamWebResponse<UserStatsForGameResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}