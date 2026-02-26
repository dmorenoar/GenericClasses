using GenericClasses.Core.Models.Items;
using GenericClasses.Core.Systems;
using GenericClasses.Core.Utils;

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


        //Generic Methods

        string fakeId = "f47ac10b-58cc-4372-a567-0e02b2c3d479";

        Console.WriteLine("Searching item...");

        Console.WriteLine(potionInventory.FindById(Guid.Parse(fakeId)) ? "Item found" : "Item not found"); 
  

        Potion firePotion = new Potion("Fire Potion", 40, PotionType.Strength);

        Console.WriteLine("Searching item...");
        Console.WriteLine(potionInventory.FindById(firePotion.Id));


        bool isPotion = potionInventory.TryFindById(firePotion.Id, out Potion? foundPotion);

        //Try to find potion before adding to inventory
        Console.WriteLine(isPotion ? foundPotion.Name : "Not found");

        //Add potion to inventory and search again
        potionInventory.AddItem(firePotion);

        isPotion = potionInventory.TryFindById(firePotion.Id, out foundPotion);

        Console.WriteLine(isPotion ? foundPotion.Name : "Potion not found");

        Weapon fakeWeapon = new Weapon("Fake Weapon", 0, WeaponType.Sword);

        weaponInventory.AddItem(fakeWeapon);

        //Generic method allos us to search for a weapon using the same method as potions
        bool isWeapon = weaponInventory.TryFindById(fakeWeapon.Id, out Weapon? foundWeapon);

        Console.WriteLine(isPotion ? foundWeapon.Name : "Weapon not found");

        //Generic inventory
        InventorySystem<Item> genericInventory = new InventorySystem<Item>(10);

        genericInventory.AddItem(iceSword);
        genericInventory.AddItem(fakeWeapon);
        genericInventory.AddItem(firePotion);

        /*
         Old way
           Potion? potion = genericInventory.GetFirstItem<Potion>();

            if (potion != null)
            {
                name = potion.Name;
            }
            else
            {
                name = null;
            }

            string finalText;

            if (name != null)
            {
                finalText = name;
            }
            else
            {
                finalText = "No potion found";
            }

            Console.WriteLine(finalText);
         */

        //New way with null-coalescing operator
        Console.WriteLine($"First Potion: {genericInventory.GetFirstItem<Potion>()?.Name ?? "No potion found"}");

        Console.WriteLine($"First Weapon: {genericInventory.GetFirstItem<Weapon>()?.Name ?? "No weapon found"}");

        //Find by specific type
        Console.WriteLine($"Exist Ice sword?:{genericInventory.FindByName<Weapon>("Ice Sword")}");

        //The compiler auto detect the type
        Tools.Print("hola");
        Tools.Print(3);
    }

}