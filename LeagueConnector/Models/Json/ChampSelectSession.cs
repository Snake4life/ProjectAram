using System.Collections.Generic;
using System.Numerics;
using LeagueConnector.Enum;
using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class ChampSelectSession
    {
        [JsonProperty("actions")]
        public List<object> Actions { get; set; }
        [JsonProperty("allowBattleBoost")]
        public bool AllowBattleBoost { get; set; }
        [JsonProperty("allowRerolling")]
        public bool AllowRerolling { get; set; }
        [JsonProperty("allowSkinSelection")]
        public bool AllowSkinSelection { get; set; }
        [JsonProperty("bans")]
        public Bans Bans { get; set; }
        [JsonProperty("chatDetails")]
        public ChatDetails ChatDetails { get; set; }
        [JsonProperty("isSpectating")]
        public bool IsSpectating { get; set; }
        [JsonProperty("localPlayerCellId")]
        public int LocalPlayerCellId { get; set; }
        [JsonProperty("myTeam")]
        public List<TeamPlayer> MyTeam { get; set; }
        [JsonProperty("rerollsRemaining")]
        public int RerollsRemaining { get; set; }
        [JsonProperty("theirTeam")]
        public List<TeamPlayer> TheirTeam { get; set; }
        [JsonProperty("timer")]
        public Timer Timer { get; set; }
        [JsonProperty("trades")]
        public List<Trade> Trades { get; set; }
    }

    public class Bans
    {
        [JsonProperty("myTeamBans")]
        public List<object> MyTeamBans { get; set; }
        [JsonProperty("numBans")]
        public int NumBans { get; set; }
        [JsonProperty("theirTeamBans")]
        public List<object> TheirTeamBans { get; set; }
    }

    public class ChatDetails
    {
        [JsonProperty("chatRoomName")]
        public string ChatRoomName { get; set; }
        [JsonProperty("chatRoomPassword")]
        public object ChatRoomPassword { get; set; }
    }

    public class TeamPlayer
    {
        [JsonProperty("assignedPosition")]
        public string AssignedPosition { get; set; }
        [JsonProperty("cellId")]
        public int CellId { get; set; }
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        [JsonProperty("championPickIntent")]
        public int ChampionPickIntent { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("playerType")]
        public EPlayerType? PlayerType { get; set; }
        [JsonProperty("selectedSkinId")]
        public int SelectedSkinId { get; set; }
        [JsonProperty("spell1Id")]
        public BigInteger Spell1Id { get; set; }
        [JsonProperty("spell2Id")]
        public BigInteger Spell2Id { get; set; }
        [JsonProperty("summonerId")]
        public int SummonerId { get; set; }
        [JsonProperty("team")]
        public int Team { get; set; }
        [JsonProperty("wardSkinId")]
        public int WardSkinId { get; set; }
    }

    public class Timer
    {
        [JsonProperty("adjustedTimeLeftInPhase")]
        public int AdjustedTimeLeftInPhase { get; set; }
        [JsonProperty("adjustedTimeLeftInPhaseInSec")]
        public int AdjustedTimeLeftInPhaseInSec { get; set; }
        [JsonProperty("internalNowInEpochMs")]
        public long InternalNowInEpochMs { get; set; }
        [JsonProperty("isInfinite")]
        public bool IsInfinite { get; set; }
        [JsonProperty("phase")]
        public EChampSelectPhaze? Phase { get; set; }
        [JsonProperty("timeLeftInPhase")]
        public int TimeLeftInPhase { get; set; }
        [JsonProperty("timeLeftInPhaseInSec")]
        public int TimeLeftInPhaseInSec { get; set; }
        [JsonProperty("totalTimeInPhase")]
        public int TotalTimeInPhase { get; set; }
    }

    public class Trade
    {
        [JsonProperty("cellId")]
        public int CellId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}