using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<PlayerGun> inv = new List<PlayerGun>();
    public void AddItem(PlayerGun gun)
    {
        if(!inv.Contains(gun))
        {
            inv.Add(gun);
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public PlayerGun gun;
    public int amount;
    public InventorySlot(PlayerGun gun, int amt)
    {
        this.gun = gun;
        this.amount = amt;
    }
}