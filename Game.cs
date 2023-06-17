// autor: Szymon Mazurek, 338191
// tytuł: "Dungeons The Text Game"
// część: Game.cs, uruchamianie gry
// data: 17.06.2023


using System;
using System.Collections.Generic;

namespace DungeonLabyrinth {
   /* The Game class initializes an object of the DungeonLabyrinthGame class and runs the game. */
   class Game
    {

        /// <summary>
        /// The Main function initializes an object of the DungeonLabyrinthGame class and runs the game.
        /// </summary>
        public static void Main(string[] args)
        {
            /* Creating an instance of the `DungeonLabyrinthGame` class and calling its `Run()` method
            to start the game. */
            DungeonLabyrinthGame game = new DungeonLabyrinthGame();
            game.Run();
        }
        
       
    }
}