using Newtonsoft.Json;
using SteamCompare.Classes.WebAPI.Utilities.JsonConverters;
using System;
using System.Collections.Generic;

namespace SteamCompare.Classes.WebAPI.Models.SteamCommunity
{
    internal class Friend
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("friend_since")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime FriendSince { get; set; }
    }

    internal class FriendsList
    {
        [JsonProperty("friends")]
        public IList<Friend> Friends { get; set; }
    }

    internal class FriendsListResultContainer
    {
        [JsonProperty("friendslist")]
        public FriendsList Result { get; set; }
    }
}