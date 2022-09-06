using System.Net.Http;
using SteamCompare.Classes.WebAPI.Interfaces;

namespace SteamCompare.Classes.WebAPI.Utilities
{
    public interface ISteamWebInterfaceFactory
    {
        SteamStore CreateSteamStoreInterface(HttpClient httpClient = null);
        T CreateSteamWebInterface<T>(HttpClient httpClient = null);
        T CreateSteamWebInterface<T>(AppId appId, HttpClient httpClient = null);
    }
}