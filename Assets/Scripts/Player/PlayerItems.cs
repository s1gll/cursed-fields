using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public List<Weapon> GetWeapons()
    {
        List<Weapon> weapons = new List<Weapon>();
        Weapon[] allWeapons = GetComponentsInChildren<Weapon>();

        foreach (var weapon in allWeapons)
        {
            weapons.Add(weapon);
        }
        return weapons;
    }
    public List<PassiveItem> GetPassiveItems()
    {
        List<PassiveItem> passiveItems = new List<PassiveItem>();
        PassiveItem[] allPassiveItems = GetComponentsInChildren<PassiveItem>();

        foreach (var passiveItem in allPassiveItems)
        {
            passiveItems.Add(passiveItem);
        }
        return passiveItems;
    }
}
