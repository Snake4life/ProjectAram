using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueConnector.Models.Json
{
    public class RunePage
    {
        [JsonProperty("current")]
        public bool Current { get; set; }
        [JsonProperty("formatVersion")]
        public int FormatVersion { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("isDeletable")]
        public bool IsDeletable { get; set; }
        [JsonProperty("isEditable")]
        public bool IsEditable { get; set; }
        [JsonProperty("isValid")]
        public bool IsValid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("primaryStyleId")]
        public int PrimaryStyleId { get; set; }
        [JsonProperty("selectedPerkIds")]
        public List<int> SelectedPerkIds { get; set; }
        [JsonProperty("subStyleId")]
        public int SubStyleId { get; set; }
    }
}