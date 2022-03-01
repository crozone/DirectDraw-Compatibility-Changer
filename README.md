# DirectDraw Compatibility Changer
A small utility for changing DirectDraw compatibility parameters on Windows Vista upwards.

Make sure you run with admin priviledges!

## Quick tutorial

* Run the game you want to add a rule for
* Click "Load Last Played"
* Type in the DirectDraw compatibility flags you wish to apply. You can try guessing these from the other existing games.
* Click "Save/Create"
* The rule should now be added.
* Restart the game and test!

## Know Flags for certain games

Game|Flags|Notes
----|-----|-----
StarCraft 1|00080000|Works with all patch versions
Diablo|00080000|
Diablo 2|00080000|
Worms World Party|00080000|
Total Annihilation|00080000|

If you have any further additions to this, create an issue with the game's name, executable ID, executable Name, and Directrdaw flags. I'll add them in!

## TODO

Add a built in template list for the above known flags. Possibly store all known good parameters in some huge JSON file, and populate a dropdown + load in parameters upon selection.

