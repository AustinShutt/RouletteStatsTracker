using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Models
{
    class Settings
    {
        public enum Theme { LIGHT, DARK};
        public enum GameType { AMERICAN, EUROPEAN}

        public Theme theme { get; set; }
        public GameType gameType { get; set; }

        Settings()
        {
            theme = Theme.LIGHT;
            gameType = GameType.AMERICAN;
        }
    }
}
