using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Player
    {
        public Room currentRoom; // - this is the current room (aisle) that the player is in
        public List<Item> inventory = new List<Item>(); // - this array contains the Items that the player has in their inventory
        public int suppliesRating = 0 ; // - this number represents the amount of general supplies gathered
        public long timeElapsed = 0; // - this number represents the time elapsed since beginning the game in seconds
        public float hallX = 1; // - this number represents where in the front or back hallway the player is.  + front/- back
        public float aisleY = 0; // - this number represents where in an aisle the player is [0 front - 3 back] 
        public bool faceBack = true; // - this boolean represents whether or not the player is facing the back of the store.
        public bool hasEscaped = false;
        

        // - CONSTRUCTOR
        public Player(Room currentRoom) 
        {
            this.currentRoom = currentRoom;
            this.inventory = inventory;
        }


        /* tester: 
         * This function will test the output of functions against a given output.
         */
        public String tester(int testNum, String actual, String expected)
        {
            if (actual == expected)
            {
                return "Test #" + testNum + " PASSED!";
            }
            else
            {
                return "Test #" + testNum + " FAILED!\n" + 
                    "Actual: " + actual + "\n" +
                    "Expctd: " + expected + "\n";

            }
        }
 
        /* examine: Item -> String
         * This function is called when the player says "examine".  It gives the description of the item
         * that they want to examine
         */
        public String examine(String item)
        {
            // - check to see if the item is in the player's inventory.  If it is, return description.
            for (int i = 0; i < this.inventory.Count(); i++)
            {
                if (this.inventory.ElementAt(i).name.ToLower() == item.ToLower())
                {
                    return this.inventory.ElementAt(i).description;
                }
            }
            // - check to see if the item is in the room.  If it is but it's not close enough to the player, it will prompt the player.
            //   if it is close enough to the player, then it will return the item's description
            for (int i = 0; i < currentRoom.items.Count(); i++)
            {
                if ((currentRoom.items.ElementAt(i).name.ToLower() == item.ToLower()) && 
                    (this.aisleY != currentRoom.items.ElementAt(i).locY))
                {
                    return "You are not close enough to examine " + currentRoom.items.ElementAt(i).name + ".\n";
                }
                if ((currentRoom.items.ElementAt(i).name.ToLower() == item.ToLower()) &&
                    (this.aisleY == currentRoom.items.ElementAt(i).locY))
                {
                    return currentRoom.items.ElementAt(i).description;
                }
            }
            return "There doesn't seem to be " + item + " nearby.\n";
        }

        /* walk: String -> String
         * This function is called when the player says "walk".  It takes in a string which is the direction the player
         * wishes to go.  Then it makes decisions regarding the player's current position and will prompt the player
         * and update the game world accordingly.
         */
        public String walk(String direction)
        {
            // - IF THE PLAYER WANTS TO MOVE FORWARD
            if (direction == "forward")
            {
                // if the player is walking into the exit
                if ((hallX == 6) && (aisleY == 2) && faceBack)
                {
                    this.hasEscaped = true;
                    return "You made it out!\n";
                }
                // - if the player is in between two aisles
                if (hallX % 1 > 0)
                {
                    return "Can't do that, there are shelves in the way.\n";
                }
                // - if the player is aligned with an aisle
                else
                {
                    // - if the player is facing the back of the store
                    if (faceBack) 
                    {
                        aisleY++;
                        // - if the player is facing the back of the store and isn't at the end yet
                        if (aisleY < 3)
                        {
                            return "You move up the aisle towards the back of the store.\n";
                        }
                        // - if the player is facing the back of the store and is at the end
                        if (aisleY == 3)
                        {
                            faceBack = false;
                            hallX *= -1;
                            return "You have reached the back end of the aisle.  Turning around, you are now facing the front of the store.\n";
                        }
                        return "error1\n";
                    }
                    // - if the player is facing the front of the store
                    else if (!faceBack)
                    {
                        aisleY--;
                        // - if the player is facing the front of the store and isn't at the front yet
                        if (aisleY > 0)
                        {
                            return "You move down the aisle towards the front of the store.\n";
                        }
                        // - if the player is facing the front of the store and is at the front
                        if (aisleY == 0)
                        {
                            faceBack = true;
                            hallX *= -1;
                            return "Your have reached the front end of the aisle.  Turning around, you are now facing the back of the store.\n";
                        }
                        return "error2\n";
                    }
                    return "error3\n";
                }
            }
            // - IF THE PLAYER WANTS TO MOVE BACKWARD
            else if (direction == "backward")
            {
                // if the player is walking into the exit
                if ((hallX == 6) && (aisleY == 2) && !faceBack)
                {
                    this.hasEscaped = true;
                    return "You made it out!\n";
                }

                // - if the player is in between two aisles
                if (hallX % 1 > 0)
                {
                    return "Can't do that, your back is to a wall.\n";
                }
                // - if the player is aligned with an aisle
                else
                {
                    // - if the player is facing the back of the store
                    if (faceBack)
                    {
                        // - if the player is facing the back of the store and isn't at the end yet
                        if (aisleY > 0)
                        {
                            aisleY--;
                            return "You move backwards down the aisle towards the front of the store, facing the back of the store.\n";
                        }
                        // - if the player is facing the back of the store and is at the end
                        if (aisleY == 0)
                        {
                            return "You have backed up as far as you can go and you're now at the front end of the store, facing the back.\n";
                        }
                        return "error4\n";
                    }
                    // - if the player is facing the front of the store
                    else if (!faceBack)
                    {
                        // - if the player is facing the front of the store and isn't at the front yet
                        if (aisleY < 3)
                        {
                            aisleY++;
                            return "You move backwards down the aisle towards the back of the store, facing the front of the store.\n";
                        }
                        // - if the player is facing the front of the store and is at the front
                        if (aisleY == 3)
                        {
                            return "You have backed up as far as you can go and you're now at the back end of the store, facing the front.\n";
                        }
                        return "error5\n";
                    }
                    return "error6\n";
                }
            }
            // - IF THE PLAYER WANTS TO MOVE LEFT
            else if (direction == "left")
            {
                // - if the player is in an aisle
                if ((aisleY < 3) && (aisleY > 0))
                {
                    return "You can't move that way, there are shelves on either side of you.\n";
                }
                // - if the player is against the back wall of the store facing front
                if (aisleY == 3) {
                    // - if the player is not against the back left wall
                    if (hallX > -6)
                    {
                        hallX -= 0.5f;
                        return "You move left against the back wall of the store.  You are facing the front.\n";
                    }
                    // - if the player is against the back left wall
                    if (hallX == -6)
                    {
                        return "You can't move any farther left, you're against the back left wall.\n";
                    }
                    return "error7\n";
                }
                // - if the player is against the front wall of the store facing back
                if (aisleY == 0)
                {
                    // - if the player is not against the front left wall
                    if (hallX > 1)
                    {
                        hallX -= 0.5f;
                        return "You move left against the front wall of the store.  You are facing the back\n";
                    }
                    // - if the player is against the front left wall
                    if (hallX == 1)
                    {
                        return "You can't move any farther left, you're against the front left wall.\n";
                    }
                    return "error8\n";
                }
                return "error9\n";
            }
            // - IF THE PLAYER WANTS TO MOVE RIGHT
            else if (direction == "right")
            {
                // - if the player is in an aisle
                if ((aisleY < 3) && (aisleY > 0))
                {
                    return "You can't move that way, there are shelves on either side of you.\n";
                }
                // - if the player is against the back wall of the store facing front
                if (aisleY == 3)
                {
                    // - if the player is not against the back right wall
                    if (hallX < -1)
                    {
                        hallX += 0.5f;
                        return "You move right against the back wall of the store.  You are facing the front.\n";
                    }
                    // - if the player is against the back right wall
                    if (hallX == -1)
                    {
                        return "You can't move any farther right, you're against the back right wall.\n";
                    }
                    return "error10\n";
                }
                // - if the player is against the front wall of the store facing back
                if (aisleY == 0)
                {
                    // - if the player is not against the front right wall
                    if (hallX < 6)
                    {
                        hallX += 0.5f;
                        return "You move right against the front wall of the store.  You are facing the back\n";
                    }
                    // - if the player is against the front right wall
                    if (hallX == 6)
                    {
                        return "You can't move any farther right, you're against the front right wall.\n";
                    }
                    return "error11\n";
                }
                return "error12\n";
            }
            // - if the player supplies an invalid argument to "walk"
            else
            {
                return "Please type \"walk\" followed by \"forward\"/\"backward\"/\"left\"/\"right\"\n";
            }
        }

        /* take: Item -> String
         * This function is called when the player says "take".  If the item is within reach, it will be added to the player's
         * inventory, prompt the player, and the item will be removed from the environment.  If not it will prompt the player.
         */
        public String take(String item)
        {
            // - check to see if the item is in the room.  If it is but it's not close enough to the player, it will prompt the player.
            //   if it is close enough to the player, then it will add the item to the player's inventory
            for (int i = 0; i < currentRoom.items.Count(); i++)
            {
                if ((currentRoom.items.ElementAt(i).name.ToLower() == item.ToLower()) &&
                    (this.aisleY != currentRoom.items.ElementAt(i).locY))
                {
                    return "You are not close enough to take " + currentRoom.items.ElementAt(i).name + ".\n";
                }
                if ((currentRoom.items.ElementAt(i).name.ToLower() == item.ToLower()) &&
                    (this.aisleY == currentRoom.items.ElementAt(i).locY))
                {
                    this.inventory.Add(currentRoom.items.ElementAt(i));
                    String taken = currentRoom.items.ElementAt(i).name;
                    currentRoom.items.Remove(currentRoom.items.ElementAt(i));
                    suppliesRating++;
                    if (this.suppliesRating >= 10)
                    {
                        return "You put " + taken + " into your backpack.  That should be enough supplies, you had better get out of here.\n";
                    }
                    return "You put " + taken + " into your backpack.\n";
                }
            }
            return "There doesn't seem to be " + item + " nearby.\n";
        }

        /* inventory: -> String
         * This function is called when the player says "inventory".  This will print the player's current inventory
         */
        public String takeInventory()
        {
            if (this.inventory.Count() == 0)
            {
                return "You haven't collected anything here yet, your backpack is almost empty.\n";
            }
            else
            {
                String result = "You have:\n";
                for (int i = 0; i < this.inventory.Count(); i++) 
                {
                    result += this.inventory.ElementAt(i).name + "\n";
                }
                return result;
            }
        }

        /* listen: -> String
         * This function is called when the player says "listen".  This is used to indicate to the player the amount of time left
         * to escape the market.
         */
        public String listen()
        {
            // within minute 1
            if (timeElapsed <= 60)
            {
                return "Silence..\n";
            }
            // within minute 2
            else if (timeElapsed <= 120) 
            {
                return "You think you heard some sort of shuffling outside, better pick up the pace..\n";
            }
            // within minute 3
            else if (timeElapsed <= 180)
            {
                return "A repetitive slamming can be heard coming from the main entrance.  Could be just one of them but it's never just " +
                    "one of them is it?..\n";
            }
            // within minute 4
            else if (timeElapsed <= 240)
            {
                return "A dreadful beat is made by their incessant pounding.  You don't have much time left..\n";
            }
            // within minute 5
            else
            {
                return "The sound of breaking glass - this is it.  It's now or never.  Time to get out of here, seriously..\n";
            }
        }
 
        /* look: -> String
         * This function is called when the player says "look".  It will describe the player's surroundings
         */
        public String look() 
        {
            String result = "";
            if (this.hallX % 1 > 0) 
            {
                return "You're in between two aisles so you can't see much.\n";
            }
            if (this.faceBack == true)
            {
                result += this.currentRoom.descriptionBack;
            }
            else
            {
                result += this.currentRoom.descriptionFront;
            }
            // - if there is nothing in the room that the player is currently in
            if (currentRoom.items.Count() == 0)
            {
                result += "  There's nothing of use in sight, maybe you should check somewhere else.\n";
                return result;
            }
            // - if there are items in the room, it will list them in order of how close they are to you
            else
            {
                for (int i = 0; i < currentRoom.items.Count(); i++)
                {
                    // - if the player is standing on the same y loc as the item
                    if ((this.aisleY - currentRoom.items.ElementAt(i).locY) == 0)
                    {
                        result += "  At your feet you find " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the player is 1 y coord away from the item
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -1) && faceBack)
                    {
                        result += "  Just up ahead you can see " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the player is 1 y coord away from the item && !faceBack
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -1) && !faceBack)
                    {
                        result += "  Just behind you appears to be " + currentRoom.items.ElementAt(i).name + " .  ";
                    }
                    // - if the item is 1 y coord behind the player
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 1) && faceBack)
                    {
                        result += "  Just behind you appears to be " + currentRoom.items.ElementAt(i).name + " .  ";
                    }
                    // - if the item is 1 y coord behind the player && !faceback
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 1) && !faceBack)
                    {
                        result += "  Just up ahead you can see " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the player is 2 y coord away from the item
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -2) && faceBack)
                    {
                        result += "  Farther down there appears to be " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the player is 2 y coord away from the item && !faceBack
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -2) && !faceBack)
                    {
                        result += "  A bit behind you you've noticed " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the item is 2 y coord behind the player
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 2) && faceBack)
                    {
                        result += "  A bit behind you you've noticed " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the item is 2 y coord behind the player && !faceBack
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 2) && !faceBack)
                    {
                        result += "  Farther down there appears to be " + currentRoom.items.ElementAt(i).name + ".  ";
                    }
                    // - if the player is 3 y coord away from the item
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -3) && faceBack)
                    {
                        result += "  Up ahead you can barely make out what appears to be " + currentRoom.items.ElementAt(i).name + ".";
                    }
                    // - if the player is 3 y coord away from the item && !faceBack
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == -3) && !faceBack)
                    {
                        result += "  Way behind where you are you can see " + currentRoom.items.ElementAt(i).name + ".";
                    }
                    // - if the item is 3 y coord behind the player
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 3) && faceBack)
                    {
                        result += "  Way behind where you are you can see " + currentRoom.items.ElementAt(i).name + ".";
                    }
                    // - if the item is 3 y coord behind the player && !faceBack
                    if (((this.aisleY - currentRoom.items.ElementAt(i).locY) == 3) && !faceBack)
                    {
                        result += "  Up ahead you can barely make out what appears to be " + currentRoom.items.ElementAt(i).name + ".";
                    }
                }
                if (this.currentRoom.name == "aisle 6")
                {
                    result += "  You can see that at the back end of this aisle there is a sign that used to glow red that now just says" +
                        " \"EXIT\" in dark spaces.";
                }
                return result;
            }
        }

        /* help: -> String
         * This function is called when the player says "help".  It will prompt the player with the commands
         */
        public String help()
        {
            return "Commands:\n" + 
                            "-Examine (followed by an object)\n" +
                            "-Walk (forward/backward/left/right)\n" +
                            "-Take (followed by an object)\n" +
                            "-Inventory\n" +
                            "-Listen\n" +
                            "-Look\n" +
                            "-Help\n";
        }
    }
}
