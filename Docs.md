## Project Description
This is a simple text-based game that was created for Object Oriented Programming
course at the University of Wroclaw. The purpose of the game is to find a Princess
in a labyrinth of Dark Dungeons. Every chamber hides some secrets as well as dangerous enemies,
and monsters. The player (terminal user) by prompting listed commands control the game action flow.

## Details of Implementation
The main logic of the game is focused on the object of a class `DungeonLabyrinthGame.cs`. This class
handles the setup of the game, so scenes, players, monsters, placing princess, creating the map and finally setting up
`currentState` object, which is crucial for information handling in the game. The main game loop
is located inside the `Run` function of this class. It's a simple while loop with a switch statement
to move between scenes in the game, so creating an illusion of movement. In each scene, we handle
a given scenario by invoking certain class methods. At each given scenario we have access to the `currentState`
to toggle changes in one class based on events in other not related objects.

## How it is done?
When the game begins player (the terminal user) finds oneself in one out of six scenes,
each connected to certain events. Those events are methods declared in a given object.
It's certainly worth noting that we pass the `currentState` object and `answerList` objects to each method.
Those two things are the most crucial parts of the game. `currentState` object allows objects
of unrelated classes to communicate and `answerList` holds the names of possible actions
for a player. This list is constantly updated accordingly to the changes happening in the game.
While playing one can find oneself in some of created chamber. Each chamber have a list of
connections to the other chambers so player can travel through the game map.

## How to play?
While playing you have access to all the actions listed in a scene. If you want to perform a certain
action you have to type the action name (letter sizing doesn't matter) into the input field, when you type it
press enter and if prompted correctly you will perform an action. Besides the listed actions
one can also choose some build in commands always accessible, those are:
- `-H` which stands for HELP, prints out the list of possible commands
- `-E` which stands for EQUIPMENT, prints out the list of the player's equipment, and might be useful for choosing the most powerful weapon
- `-P` which stands for PLAYER, prints out all the player data, so name, score, health, and equipment

# Class & Methods Description


## Chamber
The Chamber class represents a chamber in a dungeon labyrinth game and contains instance
variables and methods for updating the game state.
### M:ChooseChamberScene(CurrentState,List{String})
#### Summary
The function allows the player to choose a chamber to move to and updates the game state
accordingly.

#### Parameters
- `CurrentState`: CurrentState is an object that holds the current state of the
  game, including the current chamber the player is in, the previous chamber the player was
  in, and the list of all chambers in the game.
- `answerList`: A list of possible answers that the user can choose from in the
  current scene.

## CurrentState
The CurrentState class stores information about the current state of the game, including the
player's current chamber, list of chambers, current game scene, previous chamber, and player
information, and provides methods to handle player retreat and display player statistics and
equipment.
### M:HandlePlayerRetreat
#### Summary
The function handles the player's retreat by swapping the current chamber with the previous
chamber and setting the current game scene to "ActionForRoom".

### M:ShowPlayerStatistics
#### Summary
The function displays the player's name, score, and equipment statistics.

### M:ShowPlayerEquipment
#### Summary
The function displays the equipment of a player by iterating through their items and showing
their information.

## DungeonLabyrinthGame
The `DungeonLabyrinthGame` class defines the game's scenes, sets up the game's initial state,
and runs the game loop until the princess is found.
### M:Run
#### Summary
This function runs a game loop that switches between different game scenes until the
princess is found.

### M:SetupChambers
#### Summary
The function sets up a list of chambers with various attributes such as monsters, items, and
descriptions.

#### Returns
The method `SetupChambers()` returns a `List` of `Chamber` objects.

### M:StartScreen
#### Summary
The StartScreen function displays a welcome message and instructions for the Dungeon
Labyrinth Game and waits for the player to press Enter to begin.

## Functions
The Functions class contains several static methods for searching and filtering lists of objects
in a text-based adventure game.
### M:DungeonLabyrinth.Functions.GetIdxOfChamber(List{Chamber},String)
#### Summary
The function returns the index of a Chamber object in a List based on its name.

#### Parameters
- `chams`: A List of objects of type Chamber.
- `name`: The name of the Chamber that we are searching for in the List of Chambers
  (chams).

#### Returns
The method returns an integer value which represents the index of the first occurrence of a
Chamber object with a name that matches the input string 'name' in the given List of Chamber
objects 'chams'. If no match is found, the method returns 0.

### M:GetIdxOfHealthPotion(List{Item},String)
#### Summary
The function returns the index of a health potion item in a list of items.

#### Parameters
- `items`: A list of Item objects.
- `name`: The type of the item being searched for, represented as a string. In this
  case, it is assumed to be the type of a health potion.

#### Returns
The method returns an integer value, which is the index of the first item in the given list
of items that has a type matching the given type parameter. If no such item is found, the
method returns 0.

### M:FilterOutTypeOfItem(List{Item},String)
#### Summary
The function filters out items of a specific type from a list of items and returns a list of
their names in uppercase.

#### Parameters
- `items`: A list of objects of type Item.
- `filterQuery`: The filterQuery parameter is a string that is used to filter out
  items based on their type. The method will only add items to the filtered list if their type
  matches the filterQuery string.

#### Returns
The method is returning a list of strings that contains the names of items that match the
filter query. The names are converted to uppercase before being added to the list.

## Game
The Game class initializes an object of the DungeonLabyrinthGame class and runs the game.
### M:Main(System.String[])
#### Summary
The Main function initializes an object of the DungeonLabyrinthGame class and runs the game.

## InputHandler
The InputHandler class provides methods for getting and validating user input based on a list of
valid actions and the current state of the program.
### M:GetUserInput(List{String},CurrentState)
#### Summary
This function gets user input and validates it against a list of valid actions and the
current state.

#### Parameters
- `validActions`: A list of strings representing the possible actions that the user
  can choose from.
- `CurrentState`: CurrentState is a custom object that represents the current state
  of the game or program. It may contain information such as the player's current location,
  inventory, health, or any other relevant data. The GetUserInput method uses the CurrentState
  object to validate the user's input based on the current state of

#### Returns
The method is returning a string, which is the user's validated input.

### M:ValidateInput(String,List{String},CurrentState)
#### Summary
The function validates user input and performs certain actions based on the input.

#### Parameters
- `input`: a string representing the user input to be validated
- `validActions`: A list of valid input actions that the user can enter.
- `CurrentState`: CurrentState is an object that represents the current state of
  the game or player. It may contain information such as the player's statistics, equipment,
  location, etc.

#### Returns
The method returns a boolean value indicating whether the input is contained in the list of
valid actions.

## Item
The `Item` class defines an object that player can collect and which is placed in some Chambers.
### M:ShowItemInfo
#### Summary
The function displays information about an item in uppercase format.

## Monster
The Monster class defines properties and methods for creating and managing monsters in a game.
### M:FightWithMonster(Player,List{String},CurrentState)
#### Summary
This function handles the fight between the player and a monster, using a chosen weapon
strength and a list of possible actions.

#### Parameters
- `Player`: An object representing the player in the game, with properties such as
  health and score.
- `answerList`: A list of possible actions that the player can take during the
  fight, such as "ROLL" to roll the dice for an attack or "RETREAT" to retreat from the
  fight.
- `chosenWeaponStrength`: The strength of the weapon chosen by the player for the
  fight.
- `CurrentState`: Current
- `CurrentState`: CurrentState is an object that holds the current state of the
  game, including the current scene, current chamber, and other relevant information. It is
  used to keep track of the game's progress and to make decisions based on the player's
  actions.

### M:DisplayFightStats(Player,Int32)
#### Summary
This function displays the fight statistics of the player and the enemy in a formatted
manner.

#### Parameters
- `Player`: The Player parameter is an object of the Player class, which
  contains information about the player that is fighting against a monster, such as the
  name, strength, and health.
- `chosenWeaponStrength`: The strength of the weapon that the player has chosen to
  use in the fight.

## Player
The Player class in C# represents a player in a game and contains methods for handling the
player's actions, including discovering the princess, looking around a room, attacking or
retreating from a monster, picking up items, and choosing a room to enter.
### M:DungeonLabyrinth.Player.IsPlayerHolding(String)
#### Summary
The function checks if the player is holding an item of a certain type.

#### Parameters
- `type`: The parameter "type" is a string that represents the type of item that
  the method is checking if the player is holding. It is used to compare against the "type"
  property of each item in the "equipment" list to see if the player is holding an item of
  that type.

#### Returns
The method `IsPlayerHolding` returns a boolean value. It returns `true` if the player is
holding an item of the specified type, and `false` otherwise.

### M:PlayerChooseAction(CurrentState,List{String})
#### Summary
The function handles the player's actions in the game, including discovering the princess,
looking around a room, attacking or retreating from a monster, picking up items, and
choosing a room to enter.

#### Parameters
- `CurrentState`: CurrentState is an object that contains the current state of the
  game, including the current chamber the player is in, the previous chamber the player was
  in, any items the player is holding, and any monsters that may be present. It is used to
  keep track of the game's progress and to make

- `answerList`: A list of possible actions that the player can choose from. This
  list is cleared and updated based on the current state of the game.

### M:HandlePlayerChoice(CurrentState,List{String})
#### Summary
This function handles the player's choices during gameplay, including attacking, retreating,
drinking potions, choosing a room, and picking up items.

#### Parameters
- `CurrentState`: CurrentState is an object that represents the current state of
  the game. It contains information such as the current room the player is in, the player's
  health and equipment, and the current scene of the game.
- `answerList`: answerList is a List of strings that contains the possible actions
  that the player can take in the current state of the game. The HandlePlayerChoice method
  uses this list to prompt the player to choose an action and then handles the player's choice
  accordingly.

### M:PlayerFightMonster(CurrentState,List{String})
#### Summary
The function allows the player to choose a weapon and fight a monster in a game.

#### Parameters
- `CurrentState`: CurrentState is an object that contains the current state of the
  game, including the current chamber the player is in, the current room the player is in, and
  any items or monsters present in the room.
- `answerList`: A list of possible answers that the player can choose from during
  the fight with a monster. This list includes the option to retreat and any weapons that the
  player has in their equipment.
## Princess
The class "Princess" has properties for name and description, and a constructor that initializes
those properties. Princess is a special Class which when an object of this class is discovered the game ends. 