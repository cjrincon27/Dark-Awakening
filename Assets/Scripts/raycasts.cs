using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasts : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    // Update is called once per frame
    void Update()
    {
        float maxDistance = 30f;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward );
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.green);
        if (Physics.Raycast(ray, out hit,maxDistance,whatToDetect))
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

    }
}
