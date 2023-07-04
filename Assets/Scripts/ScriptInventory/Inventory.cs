using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private bool inventorySlots;
    public GameObject inventory;

    private int allSlots; //cuadritos donde se contendra cada objeto del inventario
    public Sprite defaultSprite;

    



    private GameObject[] slot;

    public GameObject slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            //if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventorySlots = !inventorySlots; 
        }
        if (inventorySlots == true)
        {
            inventory.SetActive(true);
            //esto es para congelar la escena
            Time.timeScale = 0f;
        }
        else
        {
            inventory.SetActive(false);
            // esto es para descongelar la escena
            Time.timeScale = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.O)) //check point
        {
            DataManager.Instance.SaveInventory(this);
        }
        if (Input.GetKeyDown(KeyCode.P)) //load inventory
        {
            LoadInventory(DataManager.Instance.LoadInventory());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Item")
        {
            GameObject itemPickedUp = other.gameObject;

            items item = itemPickedUp.GetComponent<items>();

            AddItem(itemPickedUp,item.ID,item.type,item.descripcion,item.icon);
            
        }
        
    }
    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
            
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                
                
                
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                if (itemIcon == null) slot[i].GetComponent<Slot>().icon = defaultSprite;
                else slot[i].GetComponent<Slot>().icon = itemIcon;


               // itemObject.GetComponent<items>().pickedUp = true;
               // itemObject.transform.parent = slot[i].transform;
               // itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
            
        }
    }
    [ContextMenu("ClearInventory")]
    public void Clear()
    {
        foreach(GameObject slt in slot)
        {
            slt.GetComponent<Slot>().item = null;
            slt.GetComponent<Slot>().ID = 0;
            slt.GetComponent<Slot>().type = null;
            slt.GetComponent<Slot>().description = null;
            slt.GetComponent<Slot>().icon = defaultSprite;

            slt.GetComponent<Slot>().UpdateSlot();
            slt.GetComponent<Slot>().empty = true;
        }
    }
    public void GetItems(ref List<ItemData> ToSave)
    {
        var list = new List<ItemData>();

        foreach (GameObject slt in slot)
        {
            var item = new ItemData();

            item.ID = slt.GetComponent<Slot>().ID;
            item.type = slt.GetComponent<Slot>().type;
            item.descripcion = slt.GetComponent<Slot>().description;
            item.icon = slt.GetComponent<Slot>().icon;

            print(item.descripcion);

            list.Add(item);
        }
        foreach (ItemData item in list)
        {
            print(item.ID);
        }
        ToSave.Clear();
        ToSave.AddRange(list);
    }
    public void LoadInventory(List<ItemData> itemsToLoad)
    {
        Clear();
        foreach (ItemData item in itemsToLoad)
        {
            var itemObject = new GameObject();
            if(item.ID != 0)
            {
                AddItem(itemObject, item.ID, item.type, item.descripcion, item.icon);
                DataManager.Instance.LoadDAta(item.ID);
            }
            
        }

    }
}
