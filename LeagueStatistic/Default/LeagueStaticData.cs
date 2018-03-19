namespace LeagueData.Default
{
    public static class LeagueStaticData
    {
        public static string GetChampSquareImageUrl(string version, string champName)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{champName}.png";
        }

        public static string GetChampSplashArtImageUrl(string champName, int skinId = 0)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{champName}_{skinId}.jpg";
        }
    }
}