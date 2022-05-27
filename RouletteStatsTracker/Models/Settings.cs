using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Models
{
    public class Settings
    {
        public enum Theme { LIGHT, DARK};
        public enum GameType { AMERICAN, EUROPEAN}

        public Theme theme { get; set; }
        public GameType gameType { get; set; }

        public Settings()
        {
            theme = Theme.LIGHT;
            String value = Preferences.Get("GameType", "AMERICAN");
            gameType = Enum.Parse<GameType>(value);
        }
    }
}
