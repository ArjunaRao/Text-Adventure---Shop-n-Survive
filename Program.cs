using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {

            // - Initialize all of the rooms and items in the game
            #region Initialize Objects
            Item chips = new Item("Chips", "Just your typical, run-of-the-mill potato chips.  Extra salty - makes for a nice snack.\n", 0);
            Item matches = new Item("Matches", "Shop n' Save generic \"Strike Anywhere\" matches.  A fire source is always useful.\n", 2);
            Item fryingPan = new Item("Frying pan", "A non-stick frying pan.  It looks like it has already been used but it's " +
                "in good enough condition.\n", 1);
            Item babyWipes = new Item("Baby wipes", "Googoo's Tender-Tushie baby wipes, 200 count.  Better keep these.\n", 2);
            Item canOpener = new Item("Can opener", "This tool for opening canned products is in mint condition.  Now you just have " + 
                "to find some canned goods.\n", 3);
            Item bandages = new Item("Bandages", "A box of bandages.  Or rather, bandage.  This box of 30 small adhesive bandages only " +
                "has one left.\n", 1);
            Item hose = new Item("Hose", "20 feet of rubber hose.  Looks sturdy, even if you probably won't be doing gardening any " +
                "time soon.\n", 3);
            Item cigarettes = new Item("Cigarettes", "An unopened box of 20 Coff's cigarettes.  There's a surgeon general's warning " +
                "on the back.\n", 3);
            Item vodka = new Item("Vodka", "A 30mL bottle of Space Duck vodka.  It's the kind they used to serve on airplanes.\n", 3);
            Item cereal = new Item("Cereal", "Kaptain Kreepy's sugary cereal.  It's probably stale but it can at least curb your hunger\n", 0);
            Item toothPaste = new Item("Tooth paste", "A tube of wintergreen flavored whitening tooth paste.\n", 0);
            Item salt = new Item("Salt", "A half-empty container of salt.\n", 1);
            Item scissors = new Item("Scissors", "This handy cutting tool can double as a defense mechanism.\n", 1);

            //Room entrance = new Room("the entrance", "You're standing in the checkout area facing the back of the store.  " +
               // "In front of you is aisle 1 , and to your right are more aisles.", "You're standing in the checkout area facing " +
               // "the front of the store.  Behind you is aisle 1, and to your left are more aisles.", 0.0f);
            Room aisle1 = new Room("aisle 1", "You're in aisle 1, facing the back of the store.  On either side there are " +
            "empty shelves.", "You're in aisle 1 facting the front of the store.  On either side there are empty shelves.", 1.0f);
            Room aisle2 = new Room("aisle 2", "You're in aisle 2, facing the back of the store", "You're " + 
                "in aisle 2 facing the front of the store.", 2.0f);
            
            Room aisle3 = new Room("aisle 3", "You're in aisle 3, facing the back of the store.", "You're " + 
                "in aisle 3 facing the front of the store.", 3.0f);
            Room aisle4 = new Room("aisle 4", "You're in aisle 4, facing the back of the store.", "You're " + 
                "in aisle 4 facing the front of the store.", 4.0f);
            Room aisle5 = new Room("aisle 5", "You're in aisle 5, facing the back of the store.", "You're " + 
                "in aisle 5 facing the front of the store.", 5.0f);
            Room aisle6 = new Room("aisle 6", "You're in of aisle 6, facing the back of the store.", "You're " + 
                "in aisle 6 facting the front of the store.", 6.0f);
            Room exit = new Room("the exit", "\n", "\n", 66.0f);
            aisle1.items.Add(chips);
            aisle1.items.Add(cigarettes);
            aisle2.items.Add(salt);
            aisle2.items.Add(vodka);
            aisle2.items.Add(scissors);
            aisle4.items.Add(bandages);
            aisle4.items.Add(canOpener);
            aisle5.items.Add(fryingPan);
            aisle5.items.Add(matches);
            aisle5.items.Add(toothPaste);
            aisle6.items.Add(cereal);
            aisle6.items.Add(hose);
            aisle6.items.Add(babyWipes);

            List<Room> rooms = new List<Room>();
            rooms.Add(aisle1);
            rooms.Add(aisle2);
            rooms.Add(aisle3);
            rooms.Add(aisle4);
            rooms.Add(aisle5);
            rooms.Add(aisle6);
            rooms.Add(exit);

            Player player = new Player(aisle1);

            # endregion Initialize Objects

            // - TESTS ----------------------------------------------------------------------------
            #region Test Suite

            Player testPlayer = new Player(aisle1);
            testPlayer.currentRoom = aisle4;
            testPlayer.hallX = 4;
            testPlayer.aisleY = 1;
            Console.WriteLine(player.tester(1, testPlayer.examine("bandages"), "A box of bandages.  Or rather, bandage.  " +
                "This box of 30 small adhesive bandages only has one left.\n"));
            Console.WriteLine(player.tester(2, testPlayer.examine("cigarettes"), "There doesn't seem to be cigarettes nearby.\n"));
            testPlayer.hallX = 6;
            testPlayer.aisleY = 2;
            testPlayer.faceBack = true;
            Console.WriteLine(player.tester(3, testPlayer.walk("forward"), "You made it out!\n"));
            testPlayer.hallX = 1.5f;
            Console.WriteLine(player.tester(4, testPlayer.walk("backward"), "Can't do that, your back is to a wall.\n"));
            testPlayer.aisleY = 2;
            Console.WriteLine(player.tester(5, testPlayer.walk("left"), "You can't move that way, there are shelves on either side of you.\n"));
            Console.WriteLine(player.tester(6, testPlayer.walk("right"), "You can't move that way, there are shelves on either side of you.\n"));
            testPlayer.currentRoom = aisle4;
            testPlayer.hallX = 4;
            testPlayer.aisleY = 1;
            Console.WriteLine(player.tester(7, testPlayer.take("bandages"), "You put Bandages into your backpack.\n"));
            Console.WriteLine(player.tester(8, testPlayer.take("hose"), "There doesn't seem to be hose nearby.\n"));
            Console.WriteLine(player.tester(9, testPlayer.takeInventory(), "You have:\nBandages\n"));
            Console.WriteLine(player.tester(10, testPlayer.listen(), "Silence..\n"));



            #endregion Test Suite

            // - instructions and introduction
            Console.Write("Commands:\n" +
                            "-Examine (followed by an object)\n" +
                            "-Walk (forward/backward/left/right)\n" +
                            "-Take (followed by an object)\n" +
                            "-Inventory\n" +
                            "-Listen\n" +
                            "-Look\n" +
                            "-Help\n" +
                            "Type \"walk forward\" when you are ready.\n");

            string input = Console.ReadLine(); // - the player's input will be stored in this variable

            // - This loop will begin the game or prompt the player to type begin
            while (input != "walk forward")
            {
                Console.WriteLine("Type \"walk forward\" when you are ready.");
                input = Console.ReadLine();
            }

            Console.Write("\nYou frantically shut the door behind you.  Once you catch your breath you look around " +
                        "and note that you're in a supermarket, a Shop n' Save, that's been mostly looted but " +
                        "appears to be empty.  You listen - silence, but that won't last long.  You had better " +
                        "see what supplies you can grab and find another way out because they probably saw you " +
                        "enter through the front so no doubt that's where they will be coming from.\n\n" +
                            
                        "You're in aisle 1, facing the back of the store.  On either side there are " +
                         "empty shelves.\n");

            player.currentRoom = aisle1;
            Stopwatch time = Stopwatch.StartNew();

            while ((time.ElapsedMilliseconds / 1000) < 300) {
                long before = time.ElapsedMilliseconds / 1000;
                input = Console.ReadLine().ToLower();
                Console.Write(">" + input + "\n");

                // THE INPUT LOOP----------------------------------------------------------------------------
                #region Input Loop
                // if player 

                // if player says examine
                if (input.Contains("examine"))
                {
                    String item = input.Remove(0, 8); 
                    Console.Write(player.examine(item));
                }
                // if player says walk
                if (input.Contains("walk"))
                {
                    String direction = input.Remove(0, 5);
                    String output = "";
                    output += player.walk(direction);
                    if (output == "You made it out!\n")
                    {
                        break;
                    }
                    Console.Write(output);
                }
                // if player says take
                if (input.Contains("take"))
                {
                    String item = input.Remove(0, 5);
                    Console.Write(player.take(item));
                }
                // if player says inventory
                if (input.Contains("inventory"))
                {
                    Console.Write(player.takeInventory());
                }
                // if player says listen
                if (input.Contains("listen"))
                {
                    Console.Write(player.listen());
                }
                // if player says look
                if (input.Contains("look"))
                {
                    Console.Write(player.look());
                }
                // if player says help 
                if (input.Contains("help"))
                {
                    Console.Write(player.help());
                }
                else
                {

                }
                #endregion Input Loop

                // - check to see which room the player is in and if they're in a new room, update it.
                if (Math.Abs(player.hallX) % 1 == 0)
                {
                    for (int i = 0; i < rooms.Count(); i++)
                    {
                        if (Math.Abs(player.hallX) == rooms.ElementAt(i).locX)
                        {
                            player.currentRoom = rooms.ElementAt(i);
                        }
                    }
                }

                // DEBUG LINE
                //Console.WriteLine(player.hallX + "x/" + player.aisleY + "y");

                // - How we measure the passage of time
                long after = time.ElapsedMilliseconds / 1000;
                player.timeElapsed += after - before;
            }
            // - if they escape but don't win
            if ((player.suppliesRating < 10) && player.hasEscaped == true)
            {
                Console.Write("You managed to escape with your life, but you didn't find much in that Shop n' Save.  You'll be lucky to " +
                    "survive the night with what you found there.\n");
                Console.ReadLine();
            }
            // - if they win
            else if ((player.suppliesRating >= 10) && player.hasEscaped == true)
            {
                Console.Write("Not only did you manage to get out of the Shop 'n Save before they found you, but you also found enough " +
                    "supplies to keep you going at least until the next Shopt 'n Save.");
                Console.ReadLine();
            }
            // - if they don't win
            else
            {
                Console.Write("You have failed to escape the Shop n' Save with your life, let alone any supplies.  You heard them coming but " +
                "you were too careless.  Maybe next time.");
                Console.ReadLine();
            }
        }
    }
}
