using System;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The Monster class defines properties and methods for creating and managing monsters in a game. */
    public class Monster
    {
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
        
    }
}