using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFinal : MonoBehaviour
{
    public GameObject gameObjectToActive;
    public GameObject intText;
    public bool interactable, toggle;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }

        void Update()
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObjectToActive.SetActive(true);
            }

        }
    }
}
