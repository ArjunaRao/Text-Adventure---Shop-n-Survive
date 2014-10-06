using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Item 
    {
        public String name; // - the name of the item
        public String description; // - the description of the item
        public int locY; // - this is the location of this item in the aisle

        // - CONSTRUCTOR
        public Item(String name, String description, int locY)
        {
            this.name = name;
            this.description = description;
            this.locY = locY;
        }

    }
}
