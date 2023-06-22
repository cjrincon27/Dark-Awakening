using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashligh : MonoBehaviour
{
    public GameObject inttext, flashlight_table, flashlight_hand; //Interaction with: Text, flashlight on the table, the player is holding
    public AudioSource pickup; // The pickup sound
    public bool interactable; // determines whter or not te player is looking at the flashlight and can pick it up

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                flashlight_hand.SetActive(true);
                flashlight_table.SetActive(false);
            }
        }
    }
}
