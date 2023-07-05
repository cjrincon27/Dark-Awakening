using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameObject JumpScareImg;
    public AudioSource audioSource;
     

    private bool isPlayed = false;

    void Start()
    {
       JumpScareImg.SetActive(false); // DEactive the image in the gameobject in this case the jumpscare image
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isPlayed)
            {
                JumpScareImg.SetActive(true);
                audioSource.Play();
                StartCoroutine(DisableImg());

                isPlayed = true;
            }
            
        }
    }

    IEnumerator DisableImg()
    {
        yield return new WaitForSeconds(5.0f);
        JumpScareImg.SetActive(false);
        //Destroy(JumpScareImg);
    }
}
