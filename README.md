Text-Adventure---Shop-n-Survive
===============================

This is a simple text adventure game that I wrote in C#.  Playtime is at most 5 minutes.

INSTRUCTIONS------
Commands: -Examine (followed by an object)
          -Walk (forward/backward/left/right)
          -Take (followed by an object)
	        -Inventory
          -Listen 
          -Look
          -Help

Goal: The goal is to collect at least 10 supplies, find the exit, and walk through the exit.
	    If you walk through the exit before finding at least 10, then you lose.  If you wait
    	5 minutes and don't escape, you lose.  If the player types:
	      - "examine" will give a short description of either an item in his/her inventory or an item that is 
	         at his/her feet
	      - "walk" will move the player in the direction specified (foward/backward/left/right) if possible
      	- "take" will add the item to the player's inventory where he/she can read the description at any time
      	- "inventory" will show what the player has in his/her inventory
      	- "listen" then the game will prompt the player with a cryptic indication of the time remaining
      	- "look" lets the player know where they are and what items (if any) are near them.
      	- "help" will prompt the instructions again
