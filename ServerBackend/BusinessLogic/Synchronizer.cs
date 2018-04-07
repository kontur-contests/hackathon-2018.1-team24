using System;
using System.Collections.Generic;
using GameCoreLibrary;

namespace BusinessLogic
{
    public class Synchronizer : ISynchronizer
    {
        private readonly List<Game> games = new List<Game>();

        private Game CreateNewGame(Player playerOne, Player playerTwo)
        {
            
            if (playerOne.Id == playerTwo.Id) 
                throw new ArgumentException();

            var game = new Game
            {
                FirstPlayer = playerOne,
                SecondPlayer = playerTwo,
                Levels = new Queue<Level>()
            };
            game.Levels.Enqueue(new Level());
            games.Add(game);
            return game;
        }
    }
}