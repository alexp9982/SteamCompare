using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamCompare.Classes.WebAPI.Models.SteamCommunity
{
    internal class UserGroupGid
    {
        [JsonProperty("gid")]
        public ulong Gid { get; set; }
    }

    internal class UserGroupListResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("groups")]
        public IList<UserGroupGid> Groups { get; set; }
    }

    internal class UserGroupListResultContainer
    {
        [JsonProperty("response")]
        public UserGroupListResult Result { get; set; }
    }
}