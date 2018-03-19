using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueConnector.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EChampSelectPhaze
    {
        Finalization,
        [EnumMember(Value = "BAN_PICK")]
        BanPick,
        [EnumMember(Value = "GAME_STARTING")]
        GameStarting
    }
}