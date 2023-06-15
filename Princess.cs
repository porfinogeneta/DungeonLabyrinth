using System;
using DungeonLabyrinth;

namespace DungeonLabyrinth
{
    /* The class "Princess" has properties for name and description, and a constructor that initializes
    those properties. */
    public class Princess
    {
        public String name;
        public String description;

        public Princess(String name, String description, int location)
        {
            this.name = name;
            this.description = description;
        }

    }
}