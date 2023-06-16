using System;
using System.Collections.Generic;

namespace DungeonLabyrinth
{
    /* The InputHandler class provides methods for getting and validating user input based on a list of
    valid actions and the current state of the program. */
    public static class InputHandler
    {
        /// <summary>
        /// This function gets user input and validates it against a list of valid actions and the
        /// current state.
        /// </summary>
        /// <param name="validActions">A list of strings representing the possible actions that the user
        /// can choose from.</param>
        /// <param name="CurrentState">CurrentState is a custom object that represents the current state
        /// of the game or program. It may contain information such as the player's current location,
        /// inventory, health, or any other relevant data. The GetUserInput method uses the CurrentState
        /// object to validate the user's input based on the current state of</param>
        /// <returns>
        /// The method is returning a string, which is the user's validated input.
        /// </returns>
        public static string GetUserInput(List<string> validActions, CurrentState currentState)
        {
            Functions.PrintStringList(validActions); // print possible actions
            Console.Write("Type your choice: ");
            string input = Console.ReadLine().ToUpper();
            // ask for input as long as player is giving the wrong one
            while (!ValidateInput(input, validActions, currentState))
            {
                Console.WriteLine("Enter input again: ");
                input = Console.ReadLine().ToUpper();
            }
            Console.Write("\n\n\n");
            return input;
        }
        
        /// <summary>
        /// The function validates user input and performs certain actions based on the input.
        /// </summary>
        /// <param name="input">a string representing the user input to be validated</param>
        /// <param name="validActions">A list of valid input actions that the user can enter.</param>
        /// <param name="CurrentState">CurrentState is an object that represents the current state of
        /// the game or player. It may contain information such as the player's statistics, equipment,
        /// location, etc.</param>
        /// <returns>
        /// The method returns a boolean value indicating whether the input is contained in the list of
        /// valid actions.
        /// </returns>
        private static bool ValidateInput(string input, List<string> validActions, CurrentState currentState)
        {
            if (input.ToUpper() == "-H")
            {
                Console.WriteLine($"-E - player's current equipment\n" +
                                  $"-P - to see all of the player's statistics\n" +
                                  $"-H - to prompt this message again");
            } 
            else if (input.ToUpper() == "-P")
            {
                currentState.ShowPlayerStatistics();
            } 
            else if (input.ToUpper() == "-E")
            {
                currentState.ShowPlayerEquipment();
            }
            return validActions.Contains(input.ToUpper());
        }
    }
}