using System;
using System.Collections.Generic;

namespace DungeonLabyrinth
{
   public class Player
    {
        /* These are instance variables of the `Player` class in C#. */
        public String name;
        public int health;
        public List<Item> equipment;
        public int score;

        /* This is a constructor for the Player class that takes in four parameters: name (a string),
        health (an integer), equipment (a list of Item objects), and score (an integer). It sets the
        corresponding instance variables of the Player object to the values passed in as parameters. */
        public Player(String name, int health, List<Item> equipment, int score)
        {
            this.name = name;
            this.health = health;
            this.equipment = equipment;
            this.score = score;
        }
        
        /// <summary>
        /// The function checks if the player is holding an item of a certain type.
        /// </summary>
        /// <param name="type">The parameter "type" is a string that represents the type of item that
        /// the method is checking if the player is holding. It is used to compare against the "type"
        /// property of each item in the "equipment" list to see if the player is holding an item of
        /// that type.</param>
        /// <returns>
        /// The method `IsPlayerHolding` returns a boolean value. It returns `true` if the player is
        /// holding an item of the specified type, and `false` otherwise.
        /// </returns>
        private bool IsPlayerHolding(string type)
        {
            foreach (Item item in this.equipment)
            {
                if (item.type.ToUpper() == type)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The function handles the player's actions in the game, including discovering the princess,
        /// looking around a room, attacking or retreating from a monster, picking up items, and
        /// choosing a room to enter.
        /// </summary>
        /// <param name="CurrentState">CurrentState is an object that contains the current state of the
        /// game, including the current chamber the player is in, the previous chamber the player was
        /// in, any items the player is holding, and any monsters that may be present. It is used to
        /// keep track of the game's progress and to make</param>
        /// <param name="answerList">A list of possible actions that the player can choose from. This
        /// list is cleared and updated based on the current state of the game.</param>
        public void PlayerChooseAction(CurrentState currentState, List<string> answerList)
        {
            answerList.Clear();
            // HANDLE POSSIBLE PRINCESS DISCOVERY
            if (currentState.currentCham.isWithPrincess)
            {
                Console.WriteLine("Finally you found the princess! \n" +
                                  "Now the game has come to an end");
                currentState.ShowPlayerStatistics();
                currentState.currentScene = DungeonLabyrinthGame.GameScenes.GameWon; // change scene to the winning one
            }
            else
            {

                bool roomEnter = false;
                // take care of entering a room
                if (!currentState.currentCham.visited && !IsPlayerHolding("TORCH"))
                {
                    // we need to look around only if the chamber wasn't visited
                    //look around part
                    answerList.Add("LOOK AROUND");
                    Console.WriteLine("Where am I? I need to look around the room!");
                    // ask for user input as long as one don't give a correct answer
                    string action = InputHandler.GetUserInput(answerList, currentState);
                    roomEnter = action == "LOOK AROUND" ? true : false;
                    // mark current chamber as visited before moving
                    currentState.currentCham.visited = true;
                }
                else
                {
                    // if room was visited we can enter it without looking around
                    roomEnter = true;
                }


                // taking care of proper input
                if (roomEnter)
                {
                    // taking care of possible actions
                    answerList.Clear();
                    // description, item and monster
                    Console.WriteLine("You are in: ");
                    Console.WriteLine($"Chamber name: {currentState.currentCham.name}\n" +
                                      $"Chamber description: {currentState.currentCham.description}");

                    // handle possible after 'LOOK AROUND' actions

                    // if there is a monster there is an option to attack 
                    if (currentState.currentCham.monster != null)
                    {
                        Console.WriteLine("But wait a second don't you see the monster in the room corner!?" +
                                          "With the monster on your back you won't be able to go to the other rooms, nor take any equipment!!!");
                        Console.WriteLine($"Monster Name: {currentState.currentCham.monster.name}\n" +
                                          $"Monster Description: {currentState.currentCham.monster.description}\n");
                        answerList.Add("ATTACK");
                        answerList.Add("RETREAT");
                        if (IsPlayerHolding("HEALING POTION"))
                        {
                            answerList.Add("DRINK POTION");
                        }
                    } // if there is an item we want to describe it
                    else
                    {
                        // only describe an item if it wasn't already collected
                        if (currentState.currentCham.item != null)
                        {
                            Console.WriteLine("Wow! On the floor is:");
                            currentState.currentCham.item.ShowItemInfo();
                            answerList.Add("PICK ITEM"); // only possible to pick item if there is one
                        }

                        // if there isn't a monster player can choose room or pick item
                        answerList.Add("CHOOSE ROOM");
                        // add go back action only if there is a chamber to go back
                        if (currentState.previousCham != null)
                        {
                            answerList.Add("GO BACK");
                        }
                    }
                }

                // choose room and pick item decision
                Console.WriteLine("What do you do, certainly you have some options available!");
                HandlePlayerChoice(currentState, answerList);
            }

        }

        /// <summary>
        /// This function handles the player's choices during gameplay, including attacking, retreating,
        /// drinking potions, choosing a room, and picking up items.
        /// </summary>
        /// <param name="CurrentState">CurrentState is an object that represents the current state of
        /// the game. It contains information such as the current room the player is in, the player's
        /// health and equipment, and the current scene of the game.</param>
        /// <param name="answerList">answerList is a List of strings that contains the possible actions
        /// that the player can take in the current state of the game. The HandlePlayerChoice method
        /// uses this list to prompt the player to choose an action and then handles the player's choice
        /// accordingly.</param>
        private void HandlePlayerChoice(CurrentState currentState, List<string> answerList)
        {
            Console.WriteLine("Your options:");
            string choice = InputHandler.GetUserInput(answerList, currentState);

            // handle player choices
            // attack possible only if there is a monster
            if (currentState.currentCham.monster != null)
            {
                if (choice == "ATTACK")
                {
                    // change scene to fight one
                    currentState.currentScene = DungeonLabyrinthGame.GameScenes.FightScene;
                }else if (choice == "RETREAT")
                {
                    // allow player to retreat from the fight
                    currentState.HandlePlayerRetreat();
                }else if (choice == "DRINK POTION")
                {
                    List<string> potions = Functions.FilterOutTypeOfItem(this.equipment, "HEALING POTION");
                    // handle choice of healing option
                    string potionChoice = InputHandler.GetUserInput(potions, currentState);
                    // find this potion in equipment
                    int potionIdx = Functions.GetIdxOfHealthPotion(this.equipment, potionChoice);
                    this.health += this.equipment[potionIdx].strength; // increase player's health
                    this.equipment.RemoveAt(potionIdx); // delete the potion from equipment
                    answerList.Remove("DRINK POTION"); // delete drinking current potion from actions
                    // if player has the other potion add an action to the list
                    if (IsPlayerHolding("DRINK POTION"))
                    {
                        answerList.Add("DRINK POTION");
                    }
                    
                    HandlePlayerChoice(currentState, answerList); // recursive call to allow player to choose again
                    
                }
                
            }
            // choosing room & picking item possible only if there is no monster
            else if (currentState.currentCham.monster == null)
            {
                if (choice == "CHOOSE ROOM")
                {
                    // change scene to handle room choice
                    currentState.currentScene = DungeonLabyrinthGame.GameScenes.SelectRoom;
                }
                // can choose an item if it has not been already picked
                else if (choice == "PICK ITEM" && currentState.currentCham.item != null)
                {
                    // add to player's equipment
                    this.equipment.Add(currentState.currentCham.item);
                    Console.WriteLine($"You picked {currentState.currentCham.item.name}\n" +
                                      $"Now choose the next action!");
                    currentState.currentCham.item = null;
                    answerList.Remove("PICK ITEM"); // delete pick item from possible options
                    HandlePlayerChoice(currentState, answerList); // recursive call to offer player to choose again
                }else if (choice == "GO BACK")
                {
                    currentState.HandlePlayerRetreat();
                }
                
            }
        }
        
        /// <summary>
        /// The function allows the player to choose a weapon and fight a monster in a game.
        /// </summary>
        /// <param name="CurrentState">CurrentState is an object that contains the current state of the
        /// game, including the current chamber the player is in, the current room the player is in, and
        /// any items or monsters present in the room.</param>
        /// <param name="answerList">A list of possible answers that the player can choose from during
        /// the fight with a monster. This list includes the option to retreat and any weapons that the
        /// player has in their equipment.</param>
        public void PlayerFightMonster(CurrentState currentState, List<string> answerList)
        {
            answerList.Clear();
            List<string> weaponsAtr = new List<string>();
            answerList.Add("RETREAT"); // allow player to retreat from the fight
            weaponsAtr.Add("0");
            // weapon choose menu
            Console.WriteLine("Before fight choose your weapon:");
            

            // if there is any equipment
            foreach (Item item in this.equipment)
            {
                if (item.type == "WEAPON")
                {
                    answerList.Add(item.name); // add weapons to possible choose options
                    weaponsAtr.Add(item.strength.ToString()); // we add to the weapons attributes strength
                }
            }

            // we prompts player a possibility to choose weapon
            string chosenWeapon = InputHandler.GetUserInput(answerList, currentState);
            // get weapon strength based on the index of chosen weapon
            // we get the strength value from the weaponAtr list created earlier
            int chosenWeaponStrength = int.Parse(weaponsAtr[answerList.IndexOf(chosenWeapon)]);
            
            Monster enemy = currentState.currentCham.monster;
            enemy.FightWithMonster(this, answerList, chosenWeaponStrength, currentState); // the fighting ground
        }
    }
}