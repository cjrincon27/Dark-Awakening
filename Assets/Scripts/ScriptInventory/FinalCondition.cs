using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCondition : MonoBehaviour
{
    
    public Door script;
    public GameObject inventario;
    //private string tagName = "Item";
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (inventario == true)
        {
            script.enabled = false;
        }

        if (inventario == false)
        {
            script.enabled = true;
        }
    }
}
