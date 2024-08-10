using System.Collections.Generic;
using Weapons;

namespace Inventory
{
    public class InventoryModel
    {
        public List<Weapon> Weapons { get; }= new();

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }
    }
}