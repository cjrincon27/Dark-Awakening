using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvoqueInventory : MonoBehaviour
{

    
    private bool inventoryItems;
    public GameObject inventoryCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryItems = !inventoryItems; 
        }
        if (inventoryItems == true)
{
            inventoryCanvas.SetActive(true);
}
        else
{
            inventoryCanvas.SetActive(false);
}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Destroy(other.gameObject);
            

        }
        
           
        

    }
}
