using Newtonsoft.Json;

namespace SteamCompare.Classes.WebAPI.Models
{
    internal class UGCFileDetailsResultContainer
    {
        [JsonProperty("data")]
        public UGCFileDetails Result { get; set; }
    }

    internal class UGCFileDetails
    {
        public string FileName { get; set; }
        public string URL { get; set; }
        public uint Size { get; set; }
    }
}