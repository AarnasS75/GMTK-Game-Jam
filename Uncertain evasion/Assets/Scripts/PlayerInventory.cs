using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        Gun gun = other.GetComponent<Gun>();

        if(gun)
        {
            inventory.AddItem(gun.gun);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.inv.Clear();
    }
}
