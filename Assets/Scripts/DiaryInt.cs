using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiaryInt : MonoBehaviour
{
    public GameObject cinematicaCanvas;
    private bool cinematicaActive;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diary")
        {

            Destroy(other.gameObject);
        }
        if (!cinematicaActive)

        {
            cinematicaCanvas.SetActive(true);
        }


        else
        {
            cinematicaCanvas.SetActive(false);

        }

    }
}
