using System;
using System.Collections.Generic;

namespace DungeonLabyrinth {
   /* The Game class initializes an object of the DungeonLabyrinthGame class and runs the game. */
   class Game
    {

        /// <summary>
        /// The Main function initializes an object of the DungeonLabyrinthGame class and runs the game.
        /// </summary>
        /// <param name="args">args is an array of strings that contains the command-line arguments
        /// passed to the program when it is executed. These arguments can be used to provide additional
        /// information or configuration to the program. In this case, the Main method does not use the
        /// args parameter, but it is included because it is part of the</param>
        public static void Main(string[] args)
        {
            //initialize object of game class and run the game!
            DungeonLabyrinthGame game = new DungeonLabyrinthGame();
            game.Run();
        }
        
       
    }
}