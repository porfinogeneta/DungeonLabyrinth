using System;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The `Item` class defines an object with properties such as name, description, strength, and
    type, and includes a method to display information about the item in uppercase format. */
    public class Item
    {
        public String name;
        public String description;
        public int strength;
        public String type;

        /* This is a constructor for the `Item` class that takes in four parameters: `name`,
        `description`, `strength`, and `type`. It initializes the instance variables of the `Item`
        object with the values passed in as arguments. */
        public Item(String name, String description, int strength, String type)
        {
            this.name = name;
            this.description = description;
            this.strength = strength;
            this.type = type;
        }

        /// <summary>
        /// The function displays information about an item in uppercase format.
        /// </summary>
        public void ShowItemInfo()
        {
            Console.WriteLine($"Name: {(this.name).ToUpper()}\n" +
                              $"Type: {(this.type).ToUpper()}\n" +
                              $"Strength: {this.strength}\n" +
                              $"Description: {this.description}\n"
                              );
        }
    }
}