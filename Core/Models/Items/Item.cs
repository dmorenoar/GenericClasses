using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Models.Items
{
    public class Item
    {
        //Globally Unique Identifier (GUID) is a 128-bit integer that can be used to uniquely identify items across different systems and databases.
        //By using GUIDs, we can ensure that each item has a unique identifier
        public Guid Id { get; }
        public string Name { get; set; }
        public Item(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        //Additionally, we can implement a method to generate unique IDs for items, ensuring that each item has a distinct identifier.
        public int GenerateId()
        {
            Random random = new Random();
            return random.Next(1, 1000);
        }
    }
}
