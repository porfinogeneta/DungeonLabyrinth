using System;
using System.Collections.Generic;

// global funcions for a project in a static class and with static, public methods
namespace DungeonLabyrinth
{
    /* The Functions class contains methods for getting the index of an element in a list based on a
    condition and printing a list with its corresponding index. */
    public static class Functions
    {
        // get index of element in a chams list which fulfils a condition, return index if there is such an element
        /// <summary>
        /// The function returns the index of a Chamber object in a List based on its name.
        /// </summary>
        /// <param name="chams">A List of objects of type Chamber.</param>
        /// <param name="name">The name of the Chamber that we are searching for in the List of Chambers
        /// (chams).</param>
        /// <returns>
        /// The method returns an integer value which represents the index of the first occurrence of a
        /// Chamber object with a name that matches the input string 'name' in the given List of Chamber
        /// objects 'chams'. If no match is found, the method returns 0.
        /// </returns>
        public static int GetIdxOfChamber(List<Chamber> chams, string name)
        {
            int idx = 0;
            foreach (Chamber cham in chams)
            {
                if (cham.name.ToUpper() == name)
                {
                    return idx;
                }

                idx++;
            }

            return 0;
        }

        /// <summary>
        /// The function returns the index of a health potion item in a list of items.
        /// </summary>
        /// <param name="items">A list of Item objects.</param>
        /// <param name="name">The type of the item being searched for, represented as a string. In this
        /// case, it is assumed to be the type of a health potion.</param>
        /// <returns>
        /// The method returns an integer value, which is the index of the first item in the given list
        /// of items that has a type matching the given type parameter. If no such item is found, the
        /// method returns 0.
        /// </returns>
        public static int GetIdxOfHealthPotion(List<Item> items, string name)
        {
            int idx = 0;
            foreach (Item item in items)
            {
                if (item.name.ToUpper() == name)
                {
                    return idx;
                }

                idx++;
            }

            return 0;
        }

        
        /// <summary>
        /// The function takes a list of strings and prints each element with its corresponding index.
        /// </summary>
        /// <param name="answerList">answerList is a parameter of type List<string>, which is a
        /// collection of strings that will be printed to the console. The method PrintAnyList takes
        /// this list as input and iterates through each element in the list, printing it along with its
        /// index number.</param>
        public static void PrintAnyList(List<string> answerList)
        {
            int index = 1;
            foreach (string elem in answerList)
            {
                Console.WriteLine($"{index} - {elem}");
                
                index++;
            }
        }

        public static List<string> FilterOutTypeOfItem(List<Item> items, string filterQuery)
        {
            // make a list of healing potion to let a player choose
            List<string> filtered = new List<string>();
            foreach (Item item in items)
            {
                if (item.type == filterQuery)
                {
                    filtered.Add(item.name.ToUpper());
                }
            }

            return filtered;
        }
    }
}