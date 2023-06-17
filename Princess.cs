// autor: Szymon Mazurek, 338191
// tytuł: "Dungeons The Text Game"
// część: Monster.cs, klasa reprezentująca księżniczkę
// data: 17.06.2023


using System;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The class "Princess" has properties for name and description, and a constructor that initializes
    those properties. */
    public class Princess
    {
        /* These are public properties of the `Princess` class that store the name and description of a
        princess object. They can be accessed and modified from outside the class. */
        public String name;
        public String description;

        /* This is a constructor for the `Princess` class that takes in three parameters: `name`,
        `description`, and `location`. It initializes the `name` and `description` properties of a
        `Princess` object with the values passed in as arguments. However, the `location` parameter
        is not used in the constructor. */
        public Princess(String name, String description, int location)
        {
            this.name = name;
            this.description = description;
        }

    }
}