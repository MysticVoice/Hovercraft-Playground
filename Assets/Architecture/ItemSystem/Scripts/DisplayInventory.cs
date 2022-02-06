using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int Y_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
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
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            CreateSlot(i);
        }
    }

    public Vector3 GetSlotPosition(int i)
    {
        return new Vector3(X_SPACE_BETWEEN_ITEM * (i%NUMBER_OF_COLUMN)+X_START, (-Y_SPACE_BETWEEN_ITEM) * (i/NUMBER_OF_COLUMN)+Y_START,0f);
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                CreateSlot(i);
            }
        }
    }

    private void CreateSlot(int i)
    {
        var obj = Instantiate(slotPrefab);
        obj.GetComponent<Image>().sprite = inventory.Container[i].item.sprite;
        obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
        obj.transform.parent = transform;
        obj.GetComponent<RectTransform>().localPosition = GetSlotPosition(i);
        itemsDisplayed.Add(inventory.Container[i], obj);
    }
}
