using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public new GameObject light;
    public GameObject purplelight;
    public bool toggle;
    public AudioSource toggleSound;
    public AudioSource dischargeSound;
    private int purpleLightCount;
    private bool isPurpleLightAvailable;

    void Start()
    {
        purpleLightCount = 0;
        isPurpleLightAvailable = true;

        light.SetActive(false);
        purplelight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleLight();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (isPurpleLightAvailable && purpleLightCount < 4)
            {
                TogglePurpleLight();
            }
            else
            {
                dischargeSound.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && purplelight.activeSelf)
        {
            TogglePurpleLight();
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        toggle = !toggle;
        toggleSound.Play();

        if (toggle == false)
        {
            light.SetActive(false);
            purplelight.SetActive(false);
        }
        else if (toggle == true && !purplelight.activeSelf)
        {
            light.SetActive(true);
        }
    }

    void TogglePurpleLight()
    {
        toggle = !toggle;
        toggleSound.Play();

        if (toggle == false)
        {
            purplelight.SetActive(false);
        }
        else if (toggle == true)
        {
            purplelight.SetActive(true);
            purpleLightCount++;
        }
    }
}
