using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public new GameObject light;
    public GameObject purplelight;
    public bool toggle;
    public AudioSource toggleSound;

    void Start()
    {
        if(toggle == false)
        {
            light.SetActive(false);
            purplelight.SetActive(false);
        }
        if (toggle == true)
        {
            light.SetActive(true);
            purplelight.SetActive(false);
        }
        
        if(toggle == false)
        {
            purplelight.SetActive(false);
            light.SetActive(false);
        }
        if (toggle == true)
        {
            purplelight.SetActive(true);
            light.SetActive(false);
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            
        {
            toggle = !toggle;
            toggleSound.Play();
            if(toggle == false)
            {
                light.SetActive(false);
                purplelight.SetActive(false);
            }
            if (toggle == true)
            {
                light.SetActive(true);
                purplelight.SetActive(false);
            }
        }
        
        if (Input.GetMouseButtonDown(1))
            
        {
            toggle = !toggle;
            toggleSound.Play();
            if(toggle == false)
            {
                purplelight.SetActive(false);
                light.SetActive(false);
            }
            if (toggle == true)
            {
                purplelight.SetActive(true);
                light.SetActive(false);
            }
        }
    }
}
