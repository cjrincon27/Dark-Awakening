using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private bool inventorySlots;
    public GameObject inventory;

    private int allSlots; //cuadritos donde se contendra cada objeto del inventario

    

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
            if (slot[i].GetComponent<Slot>().item == null)
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
                
                itemObject.GetComponent<items>().pickedUp = true;
                
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
            
        }
    }
}
