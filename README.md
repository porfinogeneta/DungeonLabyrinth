# DungeonLabyrinth
Simple Text Based Game

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

## How to play?
While playing you have access to all the actions listed in a scene. If you want to perform a certain
action you have to type the action name (letter sizing doesn't matter) into the input field, when you type it
press enter and if prompted correctly you will perform an action. Besides the listed actions
one can also choose some build in commands always accessible, those are:
- `-H` which stands for HELP, prints out the list of possible commands
- `-E` which stands for EQUIPMENT, prints out the list of the player's equipment, and might be useful for choosing the most powerful weapon
- `-P` which stands for PLAYER, prints out all the player data, so name, score, health, and equipment

## Compilation

Mono JIT compiler version 6.12.0.182

Compiation:
`mcs Chamber.cs CurrentState.cs DungeonLabyrinthGame.cs Functions.cs Game.cs InputHandler.cs Item.cs Monster.cs Player.cs Princess.cs -out:Game.exe
`

Generating XML file out of XML code comments
`mcs Chamber.cs CurrentState.cs DungeonLabyrinthGame.cs Functions.cs Game.cs InputHandler.cs Item.cs Monster.cs Player.cs Princess.cs /doc:Docs.xml
`
## Credits
- [Code comments](https://github.com/mintlify/writer)
- [Project Inspiration](https://github.com/Pang/KnightsAndWarlocks)
- [GPT-4 for Debugging & XML Conversion](https://openai.com)
