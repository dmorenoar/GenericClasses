using GenericClasses.Core.Models.Items;
using GenericClasses.Core.Systems;

public class Program
{
    public static void Main(string[] args)
    {
        Weapon iceSword = new Weapon("Ice Sword", 10, WeaponType.Sword);
        Weapon fireAxe = new Weapon("Fire Axe", 15, WeaponType.Axe);

        InventorySystem<Weapon> weaponInventory = new InventorySystem<Weapon>(5);

        weaponInventory.AddItem(iceSword);
        weaponInventory.AddItem(fireAxe);

        foreach (Weapon weapon in weaponInventory.GetItems())
        {
            Console.WriteLine(weapon.ToString());
        }

        /*With read-only access to the items, we cannot directly clear the inventory.
         * weaponInventory.GetItems().Clear();
        */

        InventorySystem<Potion> potionInventory = new InventorySystem<Potion>(3);

        potionInventory.AddItem(new Potion("Health Potion", 50, PotionType.Health));
        potionInventory.AddItem(new Potion("Mana Potion", 30, PotionType.Mana));

        foreach (Potion potion in potionInventory.GetItems())
        {
            Console.WriteLine(potion.ToString());
        }



    }

}