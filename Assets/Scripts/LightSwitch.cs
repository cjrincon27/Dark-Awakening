using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public new GameObject light;
    public GameObject inttext;//Interaction with text object and light object
    public bool toggle = true, interactable; //bool that determines wheter te light is oon or not and interactable determines wheter the light switch xD
    public Renderer lightBulb;// The light bulb's renderer
    public Material offlight, onlight;// when material of the light turnend on andd off
    public AudioSource lightSwitchSound;// Switch the audio
    public Animator switchAnim;//the light switc's animator
    

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
                toggle = !toggle;
                lightSwitchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }
        if(toggle == false)
        {
            light.SetActive(false);
            lightBulb.material = offlight;
        }
        if (toggle == true)
        {
            light.SetActive(true);
            lightBulb.material = onlight;
        }
    }
}
