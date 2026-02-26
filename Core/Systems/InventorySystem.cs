using GenericClasses.Core.Inferfaces;
using GenericClasses.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses.Core.Systems
{
    //Why use a Generic class with a type parameter T?
    //We can force the type parameter T to be a subclass of Item,
    //ensuring that only valid item types can be added to the inventory.
    //This can be useful for work only with classes that inherit from Item

    //Why use Generic classes?
    //Using a Genereic class allows us to create a flexible and reusable inventory
    //system that can work with different types of items (weapons, potions..)
    //or any other item type we may want to define in the future.
    //We avoid create one class for each type of item, and we can easily extend the system by
    //creating new item types that inherit from Item without modifying the InventorySystem class.
    public class InventorySystem<T> where T : Item
    {
        private List<T> items;
        private int maxSlots;

        public InventorySystem(int maxSlots)
        {
            this.maxSlots = maxSlots;
            items = new List<T>();
        }

        public bool AddItem(T item)
        {
            if (items.Count >= maxSlots)
            {
                Console.WriteLine("Inventory is full. Cannot add item.");
                return false;
            }

            items.Add(item);
            Console.WriteLine("Item added succesfully.");
            return true;
        }

        public bool RemoveItem(T item)
        {
            return items.Remove(item);
        }

        public bool isFull()
        {
            return items.Count >= maxSlots;
        }

        //We use IReadOnlyList<T> to return a read-only collection of items, preventing external modification of the inventory list.
        public IReadOnlyList<T> GetItems()
        {
            return items;
        }

        //Generic Methods: We can also implement generic methods within the InventorySystem class to perform operations on items of type T,
        //such as searching for items by name or filtering items based on specific criteria.

        public bool FindById(Guid id)
        {
            return items.FirstOrDefault(item => item.Id == id) != null;
        }

        public bool TryFindById(Guid id, out T? item)
        {
            /*
             Old method without lambda expression:
            bool Founded(Item i){
                return i.Id == id;
            }
             */

            //New method with lambda expression:
            item = items.FirstOrDefault(i => i.Id == id);
            return item != null;
        }

        //We can also implement a generic method to retrieve the first item of a specific type from the inventory,
        //demonstrating how we can work with different item types using generics.
        public TItem? GetFirstItem<TItem>() where TItem : Item
        {
            return items.OfType<TItem>().FirstOrDefault();
        }

        //Generic method to check if item exit
        public bool FindByName<TItem>(string name) where TItem : Item
        {
            return items
                .OfType<TItem>()
                .Any(item => item.Name == name);
        }

        //Find only by potion
        public bool FindByIdPotion(Guid id)
        {
            return items
                .OfType<Potion>()
                .Any(potion => potion.Id == id);
        }



    }
}
