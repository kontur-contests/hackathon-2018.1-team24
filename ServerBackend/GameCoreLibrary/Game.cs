using System.Collections.Generic;

namespace GameCoreLibrary
{
    public class Game
    {
        public Player FirstPlayer { get; set; }
        public Queue<GameLevel> Levels { get; set; }

        public GameLevel StartNextLevel()
        {
            var nextLevel = Levels.Dequeue();
            return nextLevel;
        }
    }
}