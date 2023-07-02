using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithLock : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject KeyINV;

    public AudioSource doorSound;
    public AudioSource lockedSound;


    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;





    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inReach = false;
            openText.SetActive(false);
        }
    }





    void Update()
    {
        if(KeyINV == false)
        {
            locked = false;
            hasKey = true;
        }  
        
        else
        {
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetKeyDown(KeyCode.E))  //Input.GetKeyDown(KeyCode.E
        {
            unlocked = true;
            DoorOpens();
        }

        else
        {
            DoorCloses();
        }

        if (locked && inReach && Input.GetKeyDown(KeyCode.E))
        {
            lockedSound.Play();
            //openText.SetActive(true);
            
        }




    }
    void DoorOpens ()
    {
        if (unlocked )
        {
            door.SetBool("open", true);//doorAnim.SetTrigger
            door.SetBool("close", false);//doorAnim.ResetTrigger
            doorSound.Play();
        }

    }

    void DoorCloses()
    {
        if (unlocked)
        {
            door.SetBool("open", false);//doorAnim.ResetTrigger
            door.SetBool("close", true);//doorAnim.SetTrigger
        }

    }

}
