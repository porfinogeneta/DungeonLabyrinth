// autor: Szymon Mazurek, 338191
// tytuł: "Dungeons The Text Game"
// część: Item.cs, klasa, reprezentujący element na planszy gry
// data: 17.06.2023

using System;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The `Item` class defines an object with properties such as name, description, strength, and
    type, and includes a method to display information about the item in uppercase format. */
    public class Item
    {
        public string name;
        private string description;
        public int strength;
        public string type;

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