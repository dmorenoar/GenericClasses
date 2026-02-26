# GenericClasses — Explicació del projecte

## Què fa aquest sistema?

És un **sistema d'inventari per a un videojoc RPG** simplificat. Permet gestionar col·leccions d'items (armes, pocions) amb operacions com afegir, eliminar i cercar. El punt central del projecte no és el joc en si, sinó demostrar com les **classes i mètodes genèrics de C#** resolen un problema real de disseny.

---

## El problema que resolen els genèrics

Sense genèrics, si volguessis un inventari per a armes i un altre per a pocions hauries d'escriure dues classes gairebé idèntiques:
```csharp
public class WeaponInventory { private List<Weapon> items; ... }
public class PotionInventory  { private List<Potion> items; ... }
```

Codi duplicat, difícil de mantenir, i cada nou tipus d'item requereix una classe nova. Els genèrics eliminen tot això.

---

## Classes genèriques
```csharp
public class InventorySystem<T> where T : Item
```

Aquí passen dues coses importants:

**`<T>`** és el *type parameter*, un placeholder que es substitueix per un tipus real quan instancies la classe. `T` pot ser `Weapon`, `Potion`, o qualsevol cosa. És com una variable, però per a tipus.

**`where T : Item`** és la *constraint* (restricció). No accepta qualsevol tipus, només subclasses d'`Item`. Això et dóna seguretat en temps de compilació: dins de la classe pots accedir a `item.Id` o `item.Name` amb total confiança perquè saps que `T` sempre tindrà aquestes propietats.

Quan ho uses:
```csharp
InventorySystem<Weapon> weaponInventory = new InventorySystem<Weapon>(5);
InventorySystem<Potion> potionInventory = new InventorySystem<Potion>(3);
InventorySystem<Item>   genericInventory = new InventorySystem<Item>(10);
```

El compilador genera internament una versió especialitzada per a cada tipus. Una sola classe, múltiples comportaments segurs i tipats.

---

## Mètodes genèrics

Dins d'una classe genèrica pots tenir mètodes amb el seu **propi** type parameter independent. Això és el que fa `GetFirstItem` i `FindByName`:
```csharp
public TItem? GetFirstItem<TItem>() where TItem : Item
{
    return items.OfType<TItem>().FirstOrDefault();
}
```

Fixa't que usa `TItem`, no `T`. Això li dóna un superpoder: si tens un `InventorySystem<Item>` (inventari genèric barrejat), pots cercar dins d'ell filtrant per un subtipus concret:
```csharp
genericInventory.GetFirstItem<Potion>(); // cerca només pocions dins l'inventari mixt
genericInventory.GetFirstItem<Weapon>(); // cerca només armes
```

El mateix amb `FindByName<TItem>`. El compilador a més pot **inferir el tipus automàticament** en molts casos, sense que ho escriguis explícitament, com demostra `Tools.Print`:
```csharp
public static void Print<TData>(TData data)
{
    Console.WriteLine(data);
}

Tools.Print("hola"); // el compilador infereix TData = string
Tools.Print(3);      // el compilador infereix TData = int
```

---

## La jerarquia de classes
```
Item  (base)
 ├── Weapon  (hereta Item)
 └── Potion  (hereta Item, implementa IBuy)
```

`IBuy` és una interfície que obliga `Potion` a implementar `MinPrice` i `CalcPrice()`. Cal notar que `Weapon` no implementa `IBuy`, cosa que té sentit semànticament: les armes no es "compren" en aquest sistema, només les pocions.

---

## Resum de la idea central

Els genèrics a C# són l'eina que et permet escriure codi que treballa amb **tipus com a paràmetres**. La constraint `where T : Item` és la clau de l'equilibri: tens tota la flexibilitat de reutilitzar `InventorySystem` per a qualsevol item, però sense perdre la seguretat de tipus que fa que el compilador et protegeixi d'errors. És el contrari d'usar `object` o `dynamic`, que funcionarien però et traurien aquesta protecció.
