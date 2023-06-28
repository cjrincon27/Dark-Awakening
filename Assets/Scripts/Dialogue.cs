using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text0;
    public GameObject Activator;
    public string dialogue = "Dialogue";

    public float timer = 2f;

    void Start()
    {
        text0.GetComponent<Text>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text0.GetComponent<TextMeshProUGUI>().enabled = true;
            text0.text = dialogue.ToString();
            StartCoroutine(DisableText());  
        }
    }

   IEnumerator DisableText()
   {
       yield return new WaitForSeconds(timer);
       text0.GetComponent<TextMeshProUGUI>().enabled = false;
       Destroy(Activator);
   }
}
