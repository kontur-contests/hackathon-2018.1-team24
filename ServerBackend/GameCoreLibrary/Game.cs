using System.Collections.Generic;

namespace GameCoreLibrary
{
    public class Game
    {
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }
        public Queue<Level> Levels { get; set; }

        public Level StartNextLevel()
        {
            var nextLevel = Levels.Dequeue();
            return nextLevel;
        }
        
    }
}