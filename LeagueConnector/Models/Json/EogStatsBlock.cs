using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class EogStatsBlock
    {
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        [JsonProperty("basePoints")]
        public int BasePoints { get; set; }
        [JsonProperty("battleBoostIpEarned")]
        public int BattleBoostIpEarned { get; set; }
        [JsonProperty("boostIpEarned")]
        public int BoostIpEarned { get; set; }
        [JsonProperty("boostXpEarned")]
        public int BoostXpEarned { get; set; }
        [JsonProperty("causedEarlySurrender")]
        public bool CausedEarlySurrender { get; set; }
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        [JsonProperty("coOpVsAiMinutesLeftToday")]
        public int CoOpVsAiMinutesLeftToday { get; set; }
        [JsonProperty("coOpVsAiMsecsUntilReset")]
        public int CoOpVsAiMsecsUntilReset { get; set; }
        [JsonProperty("completionBonusPoints")]
        public int CompletionBonusPoints { get; set; }
        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }
        [JsonProperty("customMinutesLeftToday")]
        public int CustomMinutesLeftToday { get; set; }
        [JsonProperty("customMsecsUntilReset")]
        public int CustomMsecsUntilReset { get; set; }
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("earlySurrenderAccomplice")]
        public bool EarlySurrenderAccomplice { get; set; }
        [JsonProperty("elo")]
        public int Elo { get; set; }
        [JsonProperty("eloChange")]
        public int EloChange { get; set; }
        [JsonProperty("experienceEarned")]
        public int ExperienceEarned { get; set; }
        [JsonProperty("experienceTotal")]
        public int ExperienceTotal { get; set; }
        [JsonProperty("firstWinBonus")]
        public int FirstWinBonus { get; set; }
        [JsonProperty("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        [JsonProperty("gameLength")]
        public int GameLength { get; set; }
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }
        [JsonProperty("gameMutators")]
        public List<string> GameMutators { get; set; }
        [JsonProperty("gameType")]
        public string GameType { get; set; }
        [JsonProperty("globalBoostXpEarned")]
        public int GlobalBoostXpEarned { get; set; }
        [JsonProperty("imbalancedTeamsNoPoints")]
        public bool ImbalancedTeamsNoPoints { get; set; }
        [JsonProperty("invalid")]
        public bool Invalid { get; set; }
        [JsonProperty("ipEarned")]
        public int IpEarned { get; set; }
        [JsonProperty("ipTotal")]
        public int IpTotal { get; set; }
        [JsonProperty("leveledUp")]
        public bool LeveledUp { get; set; }
        [JsonProperty("loyaltyBoostIpEarned")]
        public int LoyaltyBoostIpEarned { get; set; }
        [JsonProperty("loyaltyBoostXpEarned")]
        public int LoyaltyBoostXpEarned { get; set; }
        [JsonProperty("missionsXpEarned")]
        public int MissionsXpEarned { get; set; }
        [JsonProperty("myTeamStatus")]
        public string MyTeamStatus { get; set; }
        [JsonProperty("newSpells")]
        public List<object> NewSpells { get; set; }
        [JsonProperty("nextLevelXp")]
        public int NextLevelXp { get; set; }
        [JsonProperty("odinBonusIp")]
        public int OdinBonusIp { get; set; }
        [JsonProperty("partyRewardsBonusIpEarned")]
        public int PartyRewardsBonusIpEarned { get; set; }
        [JsonProperty("pointsPenalties")]
        public object PointsPenalties { get; set; }
        [JsonProperty("previousLevel")]
        public int PreviousLevel { get; set; }
        [JsonProperty("previousXpTotal")]
        public int PreviousXpTotal { get; set; }
        [JsonProperty("queueBonusEarned")]
        public int QueueBonusEarned { get; set; }
        [JsonProperty("queueType")]
        public string QueueType { get; set; }
        [JsonProperty("ranked")]
        public bool Ranked { get; set; }
        [JsonProperty("reportGameId")]
        public int ReportGameId { get; set; }
        [JsonProperty("rerollData")]
        public RerollData RerollData { get; set; }
        [JsonProperty("roomName")]
        public string RoomName { get; set; }
        [JsonProperty("roomPassword")]
        public string RoomPassword { get; set; }
        [JsonProperty("rpEarned")]
        public int RpEarned { get; set; }
        [JsonProperty("sendStatsToTournamentProvider")]
        public bool SendStatsToTournamentProvider { get; set; }
        [JsonProperty("skinId")]
        public int SkinId { get; set; }
        [JsonProperty("skinIndex")]
        public int SkinIndex { get; set; }
        [JsonProperty("summonerId")]
        public int SummonerId { get; set; }
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
        [JsonProperty("talentPointsGained")]
        public int TalentPointsGained { get; set; }
        [JsonProperty("teamBoost")]
        public TeamBoost TeamBoost { get; set; }
        [JsonProperty("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }
        [JsonProperty("teams")]
        public List<Team> Teams { get; set; }
        [JsonProperty("timeUntilNextFirstWinBonus")]
        public int TimeUntilNextFirstWinBonus { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }

    public class RerollData
    {
        [JsonProperty("pointChangeFromChampionsOwned")]
        public int PointChangeFromChampionsOwned { get; set; }
        [JsonProperty("pointChangeFromGameplay")]
        public int PointChangeFromGameplay { get; set; }
        [JsonProperty("pointsUntilNextReroll")]
        public int PointsUntilNextReroll { get; set; }
        [JsonProperty("pointsUsed")]
        public int PointsUsed { get; set; }
        [JsonProperty("previousPoints")]
        public int PreviousPoints { get; set; }
        [JsonProperty("rerollCount")]
        public int RerollCount { get; set; }
        [JsonProperty("totalPoints")]
        public int TotalPoints { get; set; }
    }

    public class TeamBoost
    {
        [JsonProperty("availableSkins")]
        public List<object> AvailableSkins { get; set; }
        [JsonProperty("ipReward")]
        public int IpReward { get; set; }
        [JsonProperty("ipRewardForPurchaser")]
        public int IpRewardForPurchaser { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("skinUnlockMode")]
        public string SkinUnlockMode { get; set; }
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
        [JsonProperty("unlocked")]
        public bool Unlocked { get; set; }
    }

    public class Team
    {
        [JsonProperty("championBans")]
        public List<object> ChampionBans { get; set; }
        [JsonProperty("fullId")]
        public string FullId { get; set; }
        [JsonProperty("isBottomTeam")]
        public bool IsBottomTeam { get; set; }
        [JsonProperty("isPlayerTeam")]
        public bool IsPlayerTeam { get; set; }
        [JsonProperty("isWinningTeam")]
        public bool IsWinningTeam { get; set; }
        [JsonProperty("memberStatusString")]
        public string MemberStatusString { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
    }

    public class Player
    {
        [JsonProperty("botPlayer")]
        public bool BotPlayer { get; set; }
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        [JsonProperty("elo")]
        public int Elo { get; set; }
        [JsonProperty("eloChange")]
        public int EloChange { get; set; }
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        [JsonProperty("isReportingDisabled")]
        public bool IsReportingDisabled { get; set; }
        [JsonProperty("items")]
        public List<int> Items { get; set; }
        [JsonProperty("leaver")]
        public bool Leaver { get; set; }
        [JsonProperty("leaves")]
        public int Leaves { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonProperty("skinIndex")]
        public int SkinIndex { get; set; }
        [JsonProperty("skinName")]
        public string SkinName { get; set; }
        [JsonProperty("spell1Id")]
        public int Spell1Id { get; set; }
        [JsonProperty("spell2Id")]
        public int Spell2Id { get; set; }
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        [JsonProperty("summonerId")]
        public int SummonerId { get; set; }
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }

    public class Stats
    {
        [JsonProperty("ASSISTS")]
        public int Assists { get; set; }
        [JsonProperty("BARRACKS_KILLED")]
        public int BarracksKilled { get; set; }
        [JsonProperty("CHAMPIONS_KILLED")]
        public int ChampionsKilled { get; set; }
        [JsonProperty("COMBAT_PLAYER_SCORE")]
        public int CombatPlayerScore { get; set; }
        [JsonProperty("GAME_ENDED_IN_EARLY_SURRENDER")]
        public int GameEndedInEarlySurrender { get; set; }
        [JsonProperty("GAME_ENDED_IN_SURRENDER")]
        public int GameEndedInSurrender { get; set; }
        [JsonProperty("GOLD_EARNED")]
        public int GoldEarned { get; set; }
        [JsonProperty("LARGEST_CRITICAL_STRIKE")]
        public int LargestCriticalStrike { get; set; }
        [JsonProperty("LARGEST_KILLING_SPREE")]
        public int LargestKillingSpree { get; set; }
        [JsonProperty("LARGEST_MULTI_KILL")]
        public int LargestMultiKill { get; set; }
        [JsonProperty("LEVEL")]
        public int Level { get; set; }
        [JsonProperty("LOSE")]
        public int Lose { get; set; }
        [JsonProperty("MAGIC_DAMAGE_DEALT_PLAYER")]
        public int MagicDamageDealtPlayer { get; set; }
        [JsonProperty("MAGIC_DAMAGE_DEALT_TO_CHAMPIONS")]
        public int MagicDamageDealtToChampions { get; set; }
        [JsonProperty("MAGIC_DAMAGE_TAKEN")]
        public int MagicDamageTaken { get; set; }
        [JsonProperty("MINIONS_KILLED")]
        public int MinionsKilled { get; set; }
        [JsonProperty("NEUTRAL_MINIONS_KILLED")]
        public int NeutralMinionsKilled { get; set; }
        [JsonProperty("NUM_DEATHS")]
        public int NumDeaths { get; set; }
        [JsonProperty("OBJECTIVE_PLAYER_SCORE")]
        public int ObjectivePlayerScore { get; set; }
        [JsonProperty("PERK0")]
        public int Perk0 { get; set; }
        [JsonProperty("PERK0_VAR1")]
        public int Perk0Var1 { get; set; }
        [JsonProperty("PERK0_VAR2")]
        public int Perk0Var2 { get; set; }
        [JsonProperty("PERK0_VAR3")]
        public int Perk0Var3 { get; set; }
        [JsonProperty("PERK1")]
        public int Perk1 { get; set; }
        [JsonProperty("PERK1_VAR1")]
        public int Perk1Var1 { get; set; }
        [JsonProperty("PERK1_VAR2")]
        public int Perk1Var2 { get; set; }
        [JsonProperty("PERK1_VAR3")]
        public int Perk1Var3 { get; set; }
        [JsonProperty("PERK2")]
        public int Perk2 { get; set; }
        [JsonProperty("PERK2_VAR1")]
        public int Perk2Var1 { get; set; }
        [JsonProperty("PERK2_VAR2")]
        public int Perk2Var2 { get; set; }
        [JsonProperty("PERK2_VAR3")]
        public int Perk2Var3 { get; set; }
        [JsonProperty("PERK3")]
        public int Perk3 { get; set; }
        [JsonProperty("PERK3_VAR1")]
        public int Perk3Var1 { get; set; }
        [JsonProperty("PERK3_VAR2")]
        public int Perk3Var2 { get; set; }
        [JsonProperty("PERK3_VAR3")]
        public int Perk3Var3 { get; set; }
        [JsonProperty("PERK4")]
        public int Perk4 { get; set; }
        [JsonProperty("PERK4_VAR1")]
        public int Perk4Var1 { get; set; }
        [JsonProperty("PERK4_VAR2")]
        public int Perk4Var2 { get; set; }
        [JsonProperty("PERK4_VAR3")]
        public int Perk4Var3 { get; set; }
        [JsonProperty("PERK5")]
        public int Perk5 { get; set; }
        [JsonProperty("PERK5_VAR1")]
        public int Perk5Var1 { get; set; }
        [JsonProperty("PERK5_VAR2")]
        public int Perk5Var2 { get; set; }
        [JsonProperty("PERK5_VAR3")]
        public int Perk5Var3 { get; set; }
        [JsonProperty("PERK_PRIMARY_STYLE")]
        public int PerkPrimaryStyle { get; set; }
        [JsonProperty("PERK_SUB_STYLE")]
        public int Perksubstyle { get; set; }
        [JsonProperty("PHYSICAL_DAMAGE_DEALT_PLAYER")]
        public int PhysicalDamageDealtPlayer { get; set; }
        [JsonProperty("PHYSICAL_DAMAGE_DEALT_TO_CHAMPIONS")]
        public int PhysicalDamageDealtToChampions { get; set; }
        [JsonProperty("PHYSICAL_DAMAGE_TAKEN")]
        public int PhysicalDamageTaken { get; set; }
        [JsonProperty("PLAYER_SCORE_1")]
        public int PlayerScore1 { get; set; }
        [JsonProperty("PLAYER_SCORE_3")]
        public int PlayerScore3 { get; set; }
        [JsonProperty("SIGHT_WARDS_BOUGHT_IN_GAME")]
        public int SightWardsBoughtInGame { get; set; }
        [JsonProperty("SPELL1_CAST")]
        public int Spell1Cast { get; set; }
        [JsonProperty("SPELL2_CAST")]
        public int Spell2Cast { get; set; }
        [JsonProperty("TEAM_EARLY_SURRENDERED")]
        public int TeamEarlySurrendered { get; set; }
        [JsonProperty("TEAM_OBJECTIVE")]
        public int TeamObjective { get; set; }
        [JsonProperty("TIME_CCING_OTHERS")]
        public int TimeCcingOthers { get; set; }
        [JsonProperty("TOTAL_DAMAGE_DEALT")]
        public int TotalDamageDealt { get; set; }
        [JsonProperty("TOTAL_DAMAGE_DEALT_TO_BUILDINGS")]
        public int TotalDamageDealtToBuildings { get; set; }
        [JsonProperty("TOTAL_DAMAGE_DEALT_TO_CHAMPIONS")]
        public int TotalDamageDealtToChampions { get; set; }
        [JsonProperty("TOTAL_DAMAGE_DEALT_TO_OBJECTIVES")]
        public int TotalDamageDealtToObjectives { get; set; }
        [JsonProperty("TOTAL_DAMAGE_DEALT_TO_TURRETS")]
        public int TotalDamageDealtToTurrets { get; set; }
        [JsonProperty("TOTAL_DAMAGE_SELF_MITIGATED")]
        public int TotalDamageSelfMitigated { get; set; }
        [JsonProperty("TOTAL_DAMAGE_TAKEN")]
        public int TotalDamageTaken { get; set; }
        [JsonProperty("TOTAL_HEAL")]
        public int TotalHeal { get; set; }
        [JsonProperty("TOTAL_PLAYER_SCORE")]
        public int TotalPlayerScore { get; set; }
        [JsonProperty("TOTAL_SCORE_RANK")]
        public int TotalScoreRank { get; set; }
        [JsonProperty("TOTAL_TIME_CROWD_CONTROL_DEALT")]
        public int TotalTimeCrowdControlDealt { get; set; }
        [JsonProperty("TOTAL_TIME_SPENT_DEAD")]
        public int TotalTimeSpentDead { get; set; }
        [JsonProperty("TRUE_DAMAGE_DEALT_PLAYER")]
        public int TrueDamageDealtPlayer { get; set; }
        [JsonProperty("TRUE_DAMAGE_DEALT_TO_CHAMPIONS")]
        public int TrueDamageDealtToChampions { get; set; }
        [JsonProperty("TRUE_DAMAGE_TAKEN")]
        public int TrueDamageTaken { get; set; }
        [JsonProperty("TURRETS_KILLED")]
        public int TurretsKilled { get; set; }
        [JsonProperty("VISION_WARDS_BOUGHT_IN_GAME")]
        public int VisionWardsBoughtInGame { get; set; }
    }
}
