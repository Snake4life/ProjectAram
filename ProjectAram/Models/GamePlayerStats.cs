using Caliburn.Micro;

namespace ProjectAram.Models
{
    public class GamePlayerStats : PropertyChangedBase
    {
        public string SummonerName { get; set; }
        public int SummonerId { get; set; }
        public int GamesPlayedWithHim { get; set; }

        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                if (value == _note) return;
                _note = value;
                NotifyOfPropertyChange();
            }
        }

        private byte[] _championIcon;
        public byte[] ChampionIcon
        {
            get => _championIcon;
            set
            {
                _championIcon = value;
                NotifyOfPropertyChange();
            }
        }
    }
}