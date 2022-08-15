using SteamKit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static SteamKit2.GC.Dota.Internal.CMsgDOTAFrostivusTimeElapsed;

namespace SteamCompare.Classes
{
    public class Class1
    {
        public static List<string> Bob(string user1, string apikey)
        {
            List<string> user1Games = new List<string>();
            try
            {
                KeyValue ownedGames;
                if (user1.Length == 17 && user1.All(char.IsDigit))
                {
                    using (dynamic playerService = WebAPI.GetInterface("IPlayerService", apikey))
                    {
                        ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user1),
                            include_appinfo: true, include_played_free_games: true);
                    }
                    var gameCount = ownedGames["game_count"].AsString();
                    if (string.IsNullOrWhiteSpace(gameCount))
                    {
                        // StatusText = "";
                        // InvalidText = "User 1 is not valid or has no games, ensure User 1 is correct and try again";
                        // ButtonEnabled = true;
                        throw new Exception("Test");
                        //return;
                    }
                }

                else
                {
                    string user1AsString;
                    using (dynamic steamUser = WebAPI.GetInterface("ISteamUser", apikey))
                    {
                        KeyValue steamId = steamUser.ResolveVanityURL(vanityurl: user1);
                        user1AsString = (steamId["steamid"].AsString());
                        if (string.IsNullOrWhiteSpace(user1AsString))
                        {
                            // StatusText = "";
                            // InvalidText = "User 1 is not valid, ensure User 1 is correct and try again";
                            // ButtonEnabled = true;
                            throw new Exception("Test");
                            //return;
                        }
                    }

                    using (dynamic playerService = WebAPI.GetInterface("IPlayerService", apikey))
                    {
                        ownedGames = playerService.GetOwnedGames(steamid: Convert.ToUInt64(user1AsString),
                            include_appinfo: true, include_played_free_games: true);
                    }

                    var gameCount = ownedGames["game_count"].AsString();
                    if (string.IsNullOrWhiteSpace(gameCount))
                    {
                        // StatusText = "";
                        // InvalidText = "User 1 has no games, ensure User 1 is correct and try again";
                        // ButtonEnabled = true;
                        throw new Exception("Test");
                        //return;
                    }
                }

                foreach (KeyValue games in ownedGames["games"].Children)
                {
                    user1Games.Add(games["name"].AsString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                // StatusText = "";
                // InvalidText = "Your API key is not valid. Ensure you followed the instructions correctly and try again";
                // ButtonEnabled = true;
                throw new Exception("Test");
                //return;
            }

            return user1Games;
        }
    }
}
