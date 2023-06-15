using System;
using System.Collections.Generic;

// mamy jedną przestrzeń z nazwami, dzięki temu klasy utworzone w projekcie są wszędzie widoczne
namespace DungeonLabyrinth
{
   public class Player
    {
        public String name;
        public int health;
        public List<Item> equipment;
        public int score;

        // // konstruktor naszego gracza
        public Player(String name, int health, List<Item> equipment, int score)
        {
            this.name = name;
            this.health = health;
            this.equipment = equipment;
            this.score = score;
        }
        
        // check if player is holding a certain Item
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

        private void HandlePlayerChoice(CurrentState currentState, List<string> answerList)
        {
            Console.WriteLine("Your options:");
            string choice = InputHandler.GetUserInput(answerList, currentState);

            // handle player choices
            // attack possible only if there is a monster
            if (currentState.currentCham.monster != null)
            {
                if (currentState.previousCham != null){ Console.WriteLine(currentState.previousCham.name);}
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

        private void DisplayFightStats(Monster enemy, int chosenWeaponStrength)
        {
            // PRINT OUT THE STATS OF PLAYER AND THE ENEMY, make the answers left aligned
            Console.WriteLine($"{"You ",-15}{this.name,-15}\n" +
                              $"{"strength: ",-15}{chosenWeaponStrength,-15}\n" +
                              $"{"health: ",-15}{this.health,-15}\n" +
                              $"{"",0}\n" +
                              $"{"Enemy ",-15} {enemy.name}\n" +
                              $"{"strength: ",-15}{enemy.strength,-15}\n" +
                              $"{"health: ",-15}{enemy.health,-15}");
        }

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
            // as long as player can fight and the monster is alive the fight is going on
            // before the fight we need to clear the answer list of all the weapons
            answerList.RemoveRange(1, answerList.Count - 1);
            Console.WriteLine("Ok, now having a weapon chosen it's time to fight!");
            Console.WriteLine("Roll your dice to hit! \n The damage of your hit are a random numbers from the range" +
                              "of 0 to the strength of your weapon.");
            
            // add roll to the possible actions
            answerList.Add("ROLL");
            while (enemy.health > 0 && this.health > 0)
            {
                
                DisplayFightStats(enemy, chosenWeaponStrength);
                
                string ipt = InputHandler.GetUserInput(answerList, currentState);
                if (ipt == "RETREAT")
                {
                    currentState.HandlePlayerRetreat();
                }
                else if (ipt == "ROLL")
                {
                    Random random = new Random(); // use random module
                    int playerAttack = random.Next(0, chosenWeaponStrength);
                    int monsterAttack = random.Next(0, enemy.strength);
                    // here we use ternary operator to shorten both fight outcomes
                    Console.WriteLine($"You rolled: {playerAttack}, Your enemy rolled: {monsterAttack}" +
                                      $"{(playerAttack >= monsterAttack ? "\n YOU WON!" : " \n YOU LOSE")}");
                    if (playerAttack >= monsterAttack)
                    {
                        enemy.health -= playerAttack; // we decrease enemy health if the player won
                    }
                    else
                    {
                        this.health -= monsterAttack;
                    }
                }
            }
            // we broke out of the loop so either the player died or the monster is gone,
            // the fight is over
            if (this.health <= 0)
            {
                Console.WriteLine("You got killed! Hopefully next time it would be better.");
                currentState.currentScene = DungeonLabyrinthGame.GameScenes.GameOver; // set the scene to game over one
            }
            // otherwise it means that the player won
            else
            {
                Console.WriteLine("Congratulations on winning this fight, but will you be able to win others too?");
                this.score += currentState.currentCham.monster.scoreToGet; // killing a monster gives player score 
                currentState.currentCham.monster = null; // monster is gone, change scene to ActionForRoom again
                currentState.currentScene = DungeonLabyrinthGame.GameScenes.ActionForRoom;
            }
        }
    }
}