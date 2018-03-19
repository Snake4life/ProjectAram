using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeagueData.Lolking.Models
{
    public class Champion
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("champion_id")]
        public int ChampionId { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
        [JsonProperty("stats")]
        public Stats Stats { get; set; }
        [JsonProperty("enemytips")]
        public List<string> Enemytips { get; set; }
        [JsonProperty("spells")]
        public List<Spell> Spells { get; set; }
        [JsonProperty("blurb")]
        public string Blurb { get; set; }
        [JsonProperty("info")]
        public Info Info { get; set; }
        [JsonProperty("lore")]
        public string Lore { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("passive")]
        public Passive Passive { get; set; }
        [JsonProperty("partype")]
        public string Partype { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("audit")]
        public Audit Audit { get; set; }
        [JsonProperty("in_rotation")]
        public bool InRotation { get; set; }
        [JsonProperty("color_palette")]
        public ColorPalette ColorPalette { get; set; }
        [JsonProperty("main_archetype")]
        public MainArchetype MainArchetype { get; set; }
        [JsonProperty("win_rate")]
        public double WinRate { get; set; }
        [JsonProperty("popularity")]
        public double Popularity { get; set; }
        [JsonProperty("media")]
        public List<Medium> Media { get; set; }
        [JsonProperty("ban_rate")]
        public double BanRate { get; set; }
        [JsonProperty("skins")]
        public List<Skin> Skins { get; set; }
    }
    public class Stats
    {
        [JsonProperty("armor")]
        public double Armor { get; set; }
        [JsonProperty("armorperlevel")]
        public double Armorperlevel { get; set; }
        [JsonProperty("attackdamage")]
        public double Attackdamage { get; set; }
        [JsonProperty("attackdamageperlevel")]
        public double Attackdamageperlevel { get; set; }
        [JsonProperty("attackrange")]
        public int Attackrange { get; set; }
        [JsonProperty("attackspeedoffset")]
        public double Attackspeedoffset { get; set; }
        [JsonProperty("attackspeedperlevel")]
        public double Attackspeedperlevel { get; set; }
        [JsonProperty("crit")]
        public int Crit { get; set; }
        [JsonProperty("critperlevel")]
        public int Critperlevel { get; set; }
        [JsonProperty("hp")]
        public double Hp { get; set; }
        [JsonProperty("hpperlevel")]
        public int Hpperlevel { get; set; }
        [JsonProperty("hpregen")]
        public double Hpregen { get; set; }
        [JsonProperty("hpregenperlevel")]
        public double Hpregenperlevel { get; set; }
        [JsonProperty("movespeed")]
        public int Movespeed { get; set; }
        [JsonProperty("mp")]
        public double Mp { get; set; }
        [JsonProperty("mpperlevel")]
        public double Mpperlevel { get; set; }
        [JsonProperty("mpregen")]
        public double Mpregen { get; set; }
        [JsonProperty("mpregenperlevel")]
        public double Mpregenperlevel { get; set; }
        [JsonProperty("spellblock")]
        public double Spellblock { get; set; }
        [JsonProperty("spellblockperlevel")]
        public double Spellblockperlevel { get; set; }
    }
    public class Spell
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
        [JsonProperty("tooltip")]
        public string Tooltip { get; set; }
        [JsonProperty("sanitizedTooltip")]
        public string SanitizedTooltip { get; set; }
        [JsonProperty("leveltip")]
        public Leveltip Leveltip { get; set; }
        [JsonProperty("resource")]
        public string Resource { get; set; }
        [JsonProperty("maxrank")]
        public int Maxrank { get; set; }
        [JsonProperty("cost")]
        public List<int> Cost { get; set; }
        [JsonProperty("costType")]
        public string CostType { get; set; }
        [JsonProperty("costBurn")]
        public string CostBurn { get; set; }
        [JsonProperty("cooldown")]
        public List<double> Cooldown { get; set; }
        [JsonProperty("cooldownBurn")]
        public string CooldownBurn { get; set; }
        [JsonProperty("effectBurn")]
        public List<string> EffectBurn { get; set; }
        [JsonProperty("vars")]
        public List<Var> Vars { get; set; }
        [JsonProperty("range")]
        public List<int> Range { get; set; }
        [JsonProperty("rangeBurn")]
        public string RangeBurn { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
    }
    public class Leveltip
    {
        [JsonProperty("label")]
        public List<string> Label { get; set; }
        [JsonProperty("effect")]
        public List<string> Effect { get; set; }
    }
    public class Var
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("coeff")]
        public List<double> Coeff { get; set; }
    }
    public class Info
    {
        [JsonProperty("attack")]
        public int Attack { get; set; }
        [JsonProperty("defense")]
        public int Defense { get; set; }
        [JsonProperty("magic")]
        public int Magic { get; set; }
        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }
    }
    public class Passive
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
    public class Audit
    {
        [JsonProperty("created")]
        public Created Created { get; set; }
        [JsonProperty("updated")]
        public Updated Updated { get; set; }
    }
    public class Created
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("isAPI")]
        public bool IsAPI { get; set; }
    }
    public class Updated
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
    public class ColorPalette
    {
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("dark")]
        public string Dark { get; set; }
        [JsonProperty("light")]
        public string Light { get; set; }
    }
    public class MainArchetype
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("specification")]
        public string Specification { get; set; }
    }
    public class Medium
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
    public class Skin
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("champion_id")]
        public int ChampionId { get; set; }
        [JsonProperty("skin_id")]
        public int SkinId { get; set; }
        [JsonProperty("num")]
        public int Num { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_sale")]
        public bool IsSale { get; set; }
        [JsonProperty("is_featured")]
        public bool IsFeatured { get; set; }
        [JsonProperty("is_new")]
        public bool IsNew { get; set; }
        [JsonProperty("is_hot")]
        public bool IsHot { get; set; }
        [JsonProperty("available")]
        public bool Available { get; set; }
        [JsonProperty("audit")]
        public Audit Audit { get; set; }
        [JsonProperty("ip_cost")]
        public int IpCost { get; set; }
        [JsonProperty("rp_cost")]
        public int RpCost { get; set; }
        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }
        [JsonProperty("media")]
        public List<Medium> Media { get; set; }
    }


}