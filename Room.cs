using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Room
    {
        public String name; // - the name of the aisle
        public List<Item> items = new List<Item>(); // - the array of items in this room
        public String descriptionBack; // - what is printed when the player is in this room and says "look" facing the back
        public String descriptionFront; // - what is printed when the player is in this room and says "look" facing the front
        public float locX;

        // - CONSTRUCTOR
        public Room(String name, String descriptionBack, String descriptionFront, float locX) {
            this.name = name;
            this.items = items;
            this.descriptionBack = descriptionBack;
            this.descriptionFront = descriptionFront;
            this.locX = locX;
        }

    }
}
