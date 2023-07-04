using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionFinal : MonoBehaviour
{
    public GameObject gameObjectToActive;
    public GameObject intText;
    public bool interactable, toggle;

    private bool activateCinematic = false; //pame

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

    }

    void Update()
    {
        if (interactable == true)

        {

            if (Input.GetKeyDown(KeyCode.E))

            {
                toggle = !toggle;
                if (toggle == true)
                {
                    gameObjectToActive.SetActive(true);
                    StartCoroutine(ActivateCinematicAfterDelay(5f)); //pame
                }

                intText.SetActive(false);
                interactable = false;
            }

        }
    }
    IEnumerator ActivateCinematicAfterDelay(float delay) //pame
    {
        yield return new WaitForSeconds(delay);
        activateCinematic = true;
    }

    void FixedUpdate()
    {
        if (activateCinematic)
        {
            activateCinematic = false;
            SceneManager.LoadScene(6);
        }
    }
}

