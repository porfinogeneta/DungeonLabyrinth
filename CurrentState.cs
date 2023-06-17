// autor: Szymon Mazurek, 338191
// tytuł: "Dungeons The Text Game"
// część: CurrentState.cs, obsługa i analiza stanu obecnego
// data: 17.06.2023

using System;
using System.Collections.Generic;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The CurrentState class stores information about the current state of the game, including the
    player's current chamber, list of chambers, current game scene, previous chamber, and player
    information, and provides methods to handle player retreat and display player statistics and
    equipment. */
    public class CurrentState
    {
        public Chamber currentCham;
        public List<Chamber> chambers;
        public DungeonLabyrinthGame.GameScenes currentScene;
        public Chamber previousCham;
        public Player player;

        /* This is a constructor for the `CurrentState` class that takes in five parameters:
        `currentCham` of type `Chamber`, `chambers` of type `List<Chamber>`, `currentScene` of type
        `DungeonLabyrinthGame.GameScenes`, `previousCham` of type `Chamber`, and `player` of type
        `Player`. It initializes the instance variables of the `CurrentState` object with the values
        passed in as parameters. */
        public CurrentState(Chamber currentCham,  List<Chamber> chambers,
        DungeonLabyrinthGame.GameScenes currentScene, Chamber previousCham, Player player)
        {
            this.currentCham = currentCham;
            this.chambers = chambers;
            this.currentScene = currentScene;
            this.previousCham = previousCham;
            this.player = player;
        }

        /// <summary>
        /// The function handles the player's retreat by swapping the current chamber with the previous
        /// chamber and setting the current game scene to "ActionForRoom".
        /// </summary>
        public void HandlePlayerRetreat()
        {
            if (previousCham != null)
            {
                // Save the current chamber into a temporary variable
                Chamber tempCham = currentCham;
                // Set the current chamber to the previous chamber
                currentCham = previousCham;
                // Set the previous chamber to the temporary variable
                previousCham = tempCham;

                currentScene = DungeonLabyrinthGame.GameScenes.ActionForRoom;
            }
        }

        /// <summary>
        /// The function displays the player's name, score, and equipment statistics.
        /// </summary>
        public void ShowPlayerStatistics()
        {
            Console.WriteLine($"\n\nStatistics:\nName: {player.name}\n" +
                              $"Score: {player.score}\n" +
                              $"Health: {player.health}");
            ShowPlayerEquipment();
            
        }

        /// <summary>
        /// The function displays the equipment of a player by iterating through their items and showing
        /// their information.
        /// </summary>
        public void ShowPlayerEquipment()
        {
            Console.WriteLine("\n\nEquipment: ");
            foreach (Item item in player.equipment)
            {
                item.ShowItemInfo();
            }
        }
        
    }
}