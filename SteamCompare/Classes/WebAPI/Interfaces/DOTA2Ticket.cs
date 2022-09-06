using System;
using AutoMapper;
using SteamCompare.Classes.WebAPI.Utilities;

namespace SteamCompare.Classes.WebAPI.Interfaces
{
    public class DOTA2Ticket : IDOTA2Ticket
    {
        private readonly IMapper mapper;
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public DOTA2Ticket(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IDOTA2Ticket_570", steamWebRequest)
                : steamWebInterface;
        }
    }
}