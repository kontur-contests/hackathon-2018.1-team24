using System;
using System.Collections.Generic;
using GameCoreLibrary;

namespace BusinessLogic
{
    public class Synchronizer : ISynchronizer
    {
        private readonly List<Game> games = new List<Game>();

        private Game CreateMultiplayer(Player playerOne, Player playerTwo)
        {
            throw new NotImplementedException();
            if (playerOne.Id == playerTwo.Id)
                throw new ArgumentException();

            var game = new Game
            {
                FirstPlayer = playerOne,
                Levels = new Queue<GameLevel>()
            };
            game.Levels.Enqueue(new GameLevel(new Level()));
            games.Add(game);
            return game;
        }

        public Game CreateSingleplayer(Player playerOne)
        {
            var game = new Game
            {
                FirstPlayer = playerOne,
                Levels = new Queue<GameLevel>()
            };
            var levelGenerator = new LevelGenerator();
            foreach (var level in levelGenerator.GenerateLevels())
            {
                game.Levels.Enqueue(level);
            }

            games.Add(game);
            return game;
        }
    }
}