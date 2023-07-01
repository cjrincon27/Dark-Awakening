using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerCursed : MonoBehaviour
{
    /*
     * He intentado hacer el código lo más simple posible para que sea entendible para aquellos que no sepan de programación o estén iniciándose.
     */

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject[] destinations; // Usa un array de destinos para poder asignar tantos destinos como desees (excepto el jugador)
    public const float distanceToFollowPlayer = 30f; // Distancia a la que empezará a seguir al jugador (dependerá de la escala de vuestro escenario, modificable desde el Editor de Unity)
    Vector3 currentTarget; // Almacena el objetivo actual al que se dirige (incluirá al jugador)
    int currentDestination = 0; // Controla el destino actual al que se dirige (del array de destinos)

    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentTarget = destinations[currentDestination].transform.position; // Asigna el primer destino para empezar a moverse
    }

    void Update()
    {
        if (Vector3.Distance(destinations[currentDestination].transform.position, transform.position) < 0.1f) // Controla cuando alcanza el destino actual (no es recomendable poner "igual a 0")
        {
            if (currentDestination == destinations.Length - 1) // Si el destino actual es el último del array ...
            {
                currentDestination = 0; // ... volverá a empezar de nuevo
            }
            else // si no ...
            {
                currentDestination++; // ... continuará con el siguiente destino
            }


            // animacion de caminar (0f)                                           // animacion de caminar (0f)
            anim.SetFloat("cursed-moviment", 0f);
        }

        if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollowPlayer) // Si el jugador está dentro de la distancia especificada para empezar a seguirlo ...
        {
            currentTarget = player.transform.position; // ... asigna como objetivo actual al jugador
            // animacion de correr (0.5f)
            anim.SetFloat("cursed-moviment", 1f);
        }
        else // si no ...
        {
            currentTarget = destinations[currentDestination].transform.position;
            // animacion de caminar (0f)                                           // animacion de caminar (0f)
            anim.SetFloat("cursed-moviment", 0f); // ... continúa con el destino que le corresponde (también controla que el jugador consiga escapar si corre más que el enemigo)
        }

        navMeshAgent.destination = currentTarget; // Asigna el objetivo al que debe ir, ya sea destino o jugador
    }
}