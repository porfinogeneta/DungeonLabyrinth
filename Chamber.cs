using System;
using System.Collections.Generic;
using System.Text;



namespace DungeonLabyrinth
/* This is a C# class called `Chamber` that represents a chamber in a dungeon labyrinth game. It has
instance variables such as `visited`, `name`, `monster`, `item`, `isWithPrincess`, `description`,
`chamIndex`, and `directions`. It also has a constructor method that initializes these instance
variables with the given values. Additionally, it has a method called `ChooseChamberScene` that
allows the player to choose a chamber to move to and updates the current state of the game
accordingly. */
{    
    public class Chamber
    {
        public Boolean visited;
        public String name;
        public Monster monster;
        public Item item;
        public Boolean isWithPrincess;
        public String description;
        public int chamIndex;

        // possible chamber's door
        public List<int> directions;

        /* This is the constructor method for the Chamber class. It takes in several parameters
        (visited, name, monster, item, isWithPrincess, description, and directions) and initializes
        the corresponding instance variables of the Chamber object with those values. */
        // constructor of a chamber
        public Chamber(Boolean visited, String name, Monster monster,
            Item item, Boolean isWithPrincess,
            String description, List<int> directions)
        {
            this.visited = visited;
            this.name = name;
            this.monster = monster;
            this.item = item;
            this.isWithPrincess = isWithPrincess;
            this.description = description;
            this.directions = directions;
        }

        /// <summary>
        /// The function allows the player to choose a chamber to move to and updates the game state
        /// accordingly.
        /// </summary>
        /// <param name="CurrentState">CurrentState is an object that holds the current state of the
        /// game, including the current chamber the player is in, the previous chamber the player was
        /// in, and the list of all chambers in the game.</param>
        /// <param name="answerList">A list of possible answers that the user can choose from in the
        /// current scene.</param>
        public void ChooseChamberScene(CurrentState currentState, List<string> answerList)
        {
            StringBuilder output = new StringBuilder();
            
            // setting up game answers
            // make a list of possible directions from the starting room
            List<int> possibleStartDirections = currentState.currentCham.directions;
            // fill in possible answers
            answerList.Clear(); // before adding answers we need to clear the list
            foreach (int i in possibleStartDirections)
            {
                answerList.Add(currentState.chambers[i].name.ToUpper());
            }
            
            output.Clear();
            output.AppendLine();
            output.AppendLine($"You are in {currentState.currentCham.name} and you can move to the other rooms.");
            Console.WriteLine(output.ToString());
            // inspiring quote place
            Console.WriteLine("Beware of dangers hiding beside each corner! Choose next room wisely!");
            
            string direction = InputHandler.GetUserInput(answerList, currentState);
            direction = direction.ToUpper();

            // update current chamber if founded correct chamber
            int idx = Functions.GetIdxOfChamber(currentState.chambers, direction);
            currentState.previousCham = currentState.currentCham; // update previous chamber
            currentState.currentCham = currentState.chambers[idx];

            // change scene
            currentState.currentScene = DungeonLabyrinthGame.GameScenes.ActionForRoom;
        }
    }
}