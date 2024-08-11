using System.Collections.Generic;
using System.Linq;
using Item;
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
        
        public void RemoveWeapon(WeaponConfig weaponConfig)
        {
            var weapon = Weapons.FirstOrDefault(weapon => weapon.WeaponConfig.Name == weaponConfig.Name);
            Weapons.Remove(weapon);
        }
    }
}