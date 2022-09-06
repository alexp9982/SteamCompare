﻿using System.Collections.Generic;

namespace SteamCompare.Classes.Models.DOTA2
{
    public class LiveLeagueGameTeamRadiantDetailModel
    {
        public uint Score { get; set; }

        public uint TowerState { get; set; }

        public uint BarracksState { get; set; }

        public IReadOnlyCollection<LiveLeagueGamePickModel> Picks { get; set; }
        public IReadOnlyCollection<LiveLeagueGameBanModel> Bans { get; set; }
        public IReadOnlyCollection<LiveLeagueGamePlayerDetailModel> Players { get; set; }
        public IReadOnlyCollection<LiveLeagueGameAbilityModel> Abilities { get; set; }

        public TowerState TowerStates { get { return new TowerState(TowerState); } }
        public TowerState BarracksStates { get { return new TowerState(BarracksState); } }
    }
}