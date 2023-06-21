// autor: Szymon Mazurek, 338191
// tytuł: "Dungeons The Text Game"
// część: Monster.cs, klasa reprezentująca przeciwników
// data: 17.06.2023

using System;
using System.Collections.Generic;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The Monster class defines properties and methods for creating and managing monsters in a game. */
    public class Monster
    {
        /* These are instance variables of the `Monster` class that define the properties of a monster
        object in the game. `name` and `description` are strings that hold the name and description
        of the monster, `health` is an integer that represents the monster's health points,
        `scoreToGet` is an integer that represents the score that the player gets for defeating the
        monster, and `strength` is an integer that represents the monster's strength in combat.
        These variables are used to initialize the properties of a `Monster` object when it is
        created and to manage the monster's behavior in the game. */
        public String name;
        public String description;
        public int health;
        public int scoreToGet;
        public int strength;

        /* This is a constructor method for the `Monster` class that takes in five parameters: `name`,
        `description`, `health`, `scoreToGet`, and `strength`. It initializes the instance variables
        of the `Monster` object with the values passed in as arguments to the constructor. */
        public Monster(String name, String description, int health, int scoreToGet, int strength)
        {
            this.name = name;
            this.description = description;
            this.health = health;
            this.scoreToGet = scoreToGet;
            this.strength = strength;
        }

        /// <summary>
        /// This function handles the fight between the player and a monster, using a chosen weapon
        /// strength and a list of possible actions.
        /// </summary>
        /// <param name="Player">An object representing the player in the game, with properties such as
        /// health and score.</param>
        /// <param name="answerList">A list of possible actions that the player can take during the
        /// fight, such as "ROLL" to roll the dice for an attack or "RETREAT" to retreat from the
        /// fight.</param>
        /// <param name="chosenWeaponStrength">The strength of the weapon chosen by the player for the
        /// fight.</param>
        /// <param name="CurrentState">CurrentState is an object that holds the current state of the
        /// game, including the current scene, current chamber, and other relevant information. It is
        /// used to keep track of the game's progress and to make decisions based on the player's
        /// actions.</param>
        public void FightWithMonster(Player player, List<string> answerList, int chosenWeaponStrength, CurrentState currentState)
        {
            // as long as player can fight and the monster is alive the fight is going on
            // before the fight we need to clear the answer list of all the weapons
            answerList.RemoveRange(1, answerList.Count - 1);
            Console.WriteLine("Ok, now having a weapon chosen it's time to fight!");
            Console.WriteLine("Roll your dice to hit! \n The damage of your hit are a random numbers from the range" +
                              "of 0 to the strength of your weapon.");
            
            // add roll to the possible actions
            answerList.Add("ROLL");
            while (player.health > 0 && this.health > 0)
            {
                
                DisplayFightStats(player, chosenWeaponStrength);
                
                string ipt = InputHandler.GetUserInput(answerList, currentState);
                if (ipt == "RETREAT")
                {
                    currentState.HandlePlayerRetreat();
                }
                else if (ipt == "ROLL")
                {
                    Random random = new Random(); // use random module
                    int playerAttack = random.Next(0, chosenWeaponStrength);
                    int monsterAttack = random.Next(0, this.strength);
                    // here we use ternary operator to shorten both fight outcomes
                    Console.WriteLine($"You rolled: {playerAttack}, Your enemy rolled: {monsterAttack}" +
                                      $"{(playerAttack >= monsterAttack ? "\n YOU WON!" : " \n YOU LOSE")}");
                    if (playerAttack >= monsterAttack)
                    {
                        this.health -= playerAttack; // we decrease enemy health if the player won
                    }
                    else
                    {
                        player.health -= monsterAttack;
                    }
                }
            }
            // we broke out of the loop so either the player died or the monster is gone,
            // the fight is over
            if (player.health <= 0)
            {
                Console.WriteLine("You got killed! Hopefully next time it would be better.");
                currentState.currentScene = DungeonLabyrinthGame.GameScenes.GameOver; // set the scene to game over one
            }
            // otherwise it means that the player won
            else
            {
                Console.WriteLine("Congratulations on winning this fight, but will you be able to win others too?");
                player.score += currentState.currentCham.monster.scoreToGet; // killing a monster gives player score 
                currentState.currentCham.monster = null; // monster is gone, change scene to ActionForRoom again
                currentState.currentScene = DungeonLabyrinthGame.GameScenes.ActionForRoom;
            }
        }
        
        /// <summary>
        /// This function displays the fight statistics of the player and the enemy in a formatted
        /// manner.
        /// </summary>
        /// <param name="Monster">The Monster parameter is an object of the Monster class, which
        /// contains information about the enemy that the player is fighting against, such as the
        /// enemy's name, strength, and health.</param>
        /// <param name="chosenWeaponStrength">The strength of the weapon that the player has chosen to
        /// use in the fight.</param>
        private void DisplayFightStats(Player player, int chosenWeaponStrength)
        {
            // PRINT OUT THE STATS OF PLAYER AND THE ENEMY, make the answers left aligned
            Console.WriteLine($"{"You ",-15}{player.name,-15}\n" +
                              $"{"strength: ",-15}{chosenWeaponStrength,-15}\n" +
                              $"{"health: ",-15}{player.health,-15}\n" +
                              $"{"",0}\n" +
                              $"{"Enemy ",-15} {this.name}\n" +
                              $"{"strength: ",-15}{this.strength,-15}\n" +
                              $"{"health: ",-15}{this.health,-15}");
        }
        
    }
}