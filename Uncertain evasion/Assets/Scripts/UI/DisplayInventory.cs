using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<PlayerGun, GameObject> itemsDisplayed = new Dictionary<PlayerGun, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.inv.Count; ++i)
        {
            var obj = Instantiate(inventory.inv[i].IconPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(inventory.inv[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.inv.Count; ++i)
        {
            if (!itemsDisplayed.ContainsKey(inventory.inv[i]))
            {
                var obj = Instantiate(inventory.inv[i].IconPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                itemsDisplayed.Add(inventory.inv[i], obj);
            }
        }
    }

    public Vector3 GetPosition(int index)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (index % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (index / NUMBER_OF_COLUMNS)), 0f);
    }
}
