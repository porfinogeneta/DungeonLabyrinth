using System;
using System.Collections.Generic;

namespace DungeonLabyrinth
{
    /* The `DungeonLabyrinthGame` class defines the game's scenes, sets up the game's initial state,
    and runs the game loop until the princess is found. */
    public class DungeonLabyrinthGame
    {
        /* This is an enumeration that defines the different scenes or states that the game can be in.
        It includes the start screen, selecting a room, taking action in a room, a fight scene, game
        over, and game won. This allows the game to keep track of what scene it is currently in and
        to perform different actions based on the current scene. */
        public enum GameScenes
        {
            StartScreen,
            SelectRoom,
            ActionForRoom,
            FightScene,
            GameOver,
            GameWon
        }

        /* These are private fields of the `DungeonLabyrinthGame` class that are used to store the
        game's current state and objects such as the player, princess, and chambers. They are
        initialized in the game constructor and are used throughout the game to keep track of the
        current state and objects. */
        private List<Chamber> chambers;
        private Player player;
        private Princess princess;
        private CurrentState currentState;
        
        /* This is the constructor method for the `DungeonLabyrinthGame` class. It sets up the initial
        state of the game by creating instances of the `Player`, `Princess`, and `Chamber` classes,
        and initializing the `currentState` object with the first chamber, the list of chambers, the
        current scene, and the player object. It also sets the initial value of `currentScene` to
        `StartScreen`. */
        public DungeonLabyrinthGame()
        {
            // set up scenes
            GameScenes currentScene = GameScenes.StartScreen;
            // set up chambers
            chambers = SetupChambers();
            // add player to the map
            player = new Player("Dude", 100, new List<Item> {new Item("HANDS", "The only thing one is born with is one's hands. They may not be strong, but they have a certain charm.", 7, "WEAPON")}, 0);
            // place princess on the map
            princess = new Princess("Diana", "First Princess, who has a heart as pure as gold and eyes that sparkle like emeralds.", 3);
            // create a current state object instance to keep track of game state
            currentState = new CurrentState(chambers[0], chambers, currentScene, null, player);
        }

        /// <summary>
        /// This function runs a game loop that switches between different game scenes until the
        /// princess is found.
        /// </summary>
        public void Run()
        {
            bool princessFound = false;
            List<string> answerList = new List<string>();

            while (!princessFound)
            {
                switch (currentState.currentScene)
                {
                    case GameScenes.StartScreen:
                        StartScreen();
                        break;
                    
                    case GameScenes.ActionForRoom:
                        Console.WriteLine("CHOOSE ACTION FOR ROOM: \n");
                        player.PlayerChooseAction(currentState, answerList);
                        break;

                    case GameScenes.SelectRoom:
                        Console.WriteLine("SELECT NEXT ROOM: \n");
                        currentState.currentCham.ChooseChamberScene(currentState, answerList);
                        break;
                    
                    case GameScenes.FightScene:
                        Console.WriteLine("FIGHT WITH MONSTER SCENE: \n");
                        player.PlayerFightMonster(currentState, answerList);
                        break;
                    
                    case GameScenes.GameOver:
                        Console.WriteLine("GAME OVER! \n");
                        Console.WriteLine("Game Over!\n Press Enter if you want to play again...");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                        while (keyInfo.Key != ConsoleKey.Enter);
                        currentState.currentScene = GameScenes.StartScreen;
                        break;
                    case GameScenes.GameWon:
                        Console.WriteLine("CONGRATS ON WINNING THIS GAME!");
                        Console.WriteLine(princess.description);
                        princessFound = true; // end the loop
                        break;
                }
            }
        }

        /// <summary>
        /// The function sets up a list of chambers with various attributes such as monsters, items, and
        /// descriptions.
        /// </summary>
        /// <returns>
        /// The method `SetupChambers()` returns a `List` of `Chamber` objects.
        /// </returns>
        private List<Chamber> SetupChambers()
        {
            List<Chamber> chams = new List<Chamber>
            {
                new Chamber(true, "Start Chamber - Darkest Cave", null, 
                    new Item("Herbal Poultice", "A bundle of herbs imbued with the soothing essence of the garden.", 10, "HEALING POTION"),
                    false, "The entrance to the dungeon, dimly lit and foreboding, whispers of long-lost tales.", new List<int>{1, 2, 3}),
                new Chamber(false, "1st Chamber - Den of Shadows", new Monster("Rakshasa", "The Rakshasa, a terrifying, feline creature with powerful claws that strike fear.", 10, 5, 4),
                    new Item("Sword of Silence", "A two-handed sword known to silence the chaos in the darkness.", 10, "WEAPON"),
                    false, "An eerie ambiance fills the air, and the patter of raindrops echoes eerily.", new List<int>{2, 4, 0, 5}),
                new Chamber(false, "2nd Chamber - Serpent's Lair", new Monster("Giant Serpent", "A massive snake with glistening scales slithers menacingly, venom dripping from its fangs", 50, 10, 10),
                    new Item("TORCH", "An ancient torch that casts flickering shadows and reveals secrets of the dungeon.", 0, "UTILITY"),
                    false, "Venomous snakes slither eerily along the walls, watching your every move with anticipation.", new List<int>{0, 4, 6}),
                new Chamber(false, "3rd Chamber - Enchanted Library", new Monster("Book Wyrm", "A deceptively swift creature that feeds on knowledge, striking with razor-sharp spine projectiles.", 40, 8, 6), new Item("Tome of Healing", "A powerful tome, bonded to the holder, allows for healing magic which restores 20 HP.", 20, "HEALING POTION"), false, "Dust-covered books and illuminated scrolls lining the shelves, emanate a magical aura.", new List<int>{0, 6, 7}),
                new Chamber(false, "4th Chamber - Whispering Catacombs", new Monster("Restless Spirits", "Pained cries fill the room as disembodied spirits attempt to break free from their torment.", 35, 6, 8), new Item("Amulet of Tranquility", "A beautiful amulet that captures the whispers of the spirits, dispelling melancholy.", 12, "HEALING POTION"), false, "The chilling whispers from lost souls fill the vaulted chamber, an unbearable sadness lingers.", new List<int>{1, 5}),
                new Chamber(false, "5th Chamber - Emerald Garden", new Monster("Vine Lasher", "Sentient bundles of vines that ensnare and lash out at intruders with ferocity.", 45, 9, 8), new Item("Herbal Poultice", "A bundle of herbs imbued with the soothing essence of the garden.", 10, "HEALING POTION"), false, "Verdant vines and vibrant flora blossom under a mysterious light, a soothing sanctuary.", new List<int>{1, 6}),
                new Chamber(false, "6th Chamber - Alchemist's Study", new Monster("Lab Experiment", "A horrific, mutant creature, created through a failed alchemical experiment.", 60, 15, 10), new Item("Alchemical Bomb", "With a single throw, unleash a devastating explosion upon your foes.", 25, "WEAPON"), false, "Broken beakers and spilled potions lay scattered, evidence of desperate attempts to understand the arcane.", new List<int>{4, 3, 2}),
                new Chamber(false, "7th Chamber - Crystal Cavern", new Monster("Crystal Golem", "A hulking, crystal-encased golem that shatters the ground with its thunderous stomp.", 80, 18, 14), new Item("Gem of Clarity", "A gemstone that grants a clear mind, increasing mental resistance.", 15, "WEAPON"), true, "The mesmerizing glow of colorful crystals casts dancing reflections on the chamber walls.", new List<int>{3})
            };

            return chams;
        }

        /// <summary>
        /// The StartScreen function displays a welcome message and instructions for the Dungeon
        /// Labyrinth Game and waits for the player to press Enter to begin.
        /// </summary>
        private void StartScreen()
        {
            Console.WriteLine("Welcome to the Dungeon Labyrinth Game!\n" +
                              $"Your mission is to rescue Princess {princess.name} from the dungeon.\n" +
                              $"On your mission to accomplish this you will have to overcome many obstacles.\n" +
                              $"Player Control is performed via Terminal commands which one can choose from the listed options" +
                              $"in each option menu. Moreover player can always prompt given commands: \n" +
                              $"-E - player's current equipment\n" +
                              $"-P - to see all of the player's statistics\n" +
                              $"-H - to prompt this message again");
            Console.WriteLine("Press Enter to begin");
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            // move to the next scene
            currentState.currentScene = GameScenes.ActionForRoom;
            while (keyInfo.Key != ConsoleKey.Enter);
        }
    }
}