using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject[] destinations; // Destinos a los que ira el jugador
    public const float distanceToFollowPlayer = 10f; // Distancia a la que empezará a seguir al jugador
    Vector3 currentTarget; // el objetivo actual al que se dirige (incluirá al jugador)
    int currentDestination = 0; // Controla el destino actual al que se dirige (del array de destinos)

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentTarget = destinations[currentDestination].transform.position; // Asigna el primer destino para empezar a moverse
    }

    void Update()
    {
        if (Vector3.Distance(destinations[currentDestination].transform.position, transform.position) < 0.1f) // Valida cuando alcanza el destino actual
        {
            if (currentDestination == destinations.Length - 1) // Si el destino actual es el último del array 
            {
                currentDestination = 0; // volverá a empezar de nuevo
            }
            else // si no ...
            {
                currentDestination++; // continuará con el siguiente destino
            }


            // animacion de caminar (0f)                                       
            anim.SetFloat("Moviment", 0f);
        }

        if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollowPlayer) // Si el jugador está dentro del rango
        {
            currentTarget = player.transform.position; // asigna como objetivo actual al jugador
            // animacion de correr (0.5f)
            anim.SetFloat("Moviment", 0.5f);
        }
        else // si no ...
        {
            currentTarget = destinations[currentDestination].transform.position; // continúa con el destino siguiente
            // animacion de caminar (0f)                                        
            anim.SetFloat("Moviment", 0f); 
        }

        navMeshAgent.destination = currentTarget; // Asigna el objetivo al que debe ir, ya sea destino o jugador
    }
}