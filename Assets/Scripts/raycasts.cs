using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasts : MonoBehaviour
{
    [SerializeField] private LayerMask whatToDetect;
    public GameObject linterna;
    public GameObject enemiesContainer;
    private Transform[] enemyTransforms;
    private Vector3[] originalPositions;

    void Start()
    {
        int enemyCount = enemiesContainer.transform.childCount;
        enemyTransforms = new Transform[enemyCount];
        originalPositions = new Vector3[enemyCount];

        for (int i = 0; i < enemyCount; i++)
        {
            enemyTransforms[i] = enemiesContainer.transform.GetChild(i);
            originalPositions[i] = enemyTransforms[i].position;
        }
    }

    void Update()
    {
        if (!linterna.activeSelf)
        {
            return;
        }

        float maxDistance = 10f;
        RaycastHit hit;

        Ray ray = new Ray(linterna.transform.position, linterna.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);
        if (Physics.Raycast(ray, out hit, maxDistance, whatToDetect))
        {
            foreach (Transform enemyTransform in enemyTransforms)
            {
                if (linterna.activeSelf && hit.collider.gameObject == enemyTransform.gameObject)
                {
                    StartCoroutine(DisappearAndAppear(enemyTransform));
                }
            }
        }
    }

    private IEnumerator DisappearAndAppear(Transform enemyTransform)
    {
        // Desactivar el enemigo
        enemyTransform.gameObject.SetActive(false);

        yield return new WaitForSeconds(5f);

        // Activar el enemigo y restablecer su posición original
        enemyTransform.gameObject.SetActive(true);
        int index = System.Array.IndexOf(enemyTransforms, enemyTransform);
        enemyTransform.position = originalPositions[index];
    }
}
