using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerCursed : MonoBehaviour
{
    /*
     * He intentado hacer el c�digo lo m�s simple posible para que sea entendible para aquellos que no sepan de programaci�n o est�n inici�ndose.
     */

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject[] destinations; // Usa un array de destinos para poder asignar tantos destinos como desees (excepto el jugador)
    public const float distanceToFollowPlayer = 30f; // Distancia a la que empezar� a seguir al jugador (depender� de la escala de vuestro escenario, modificable desde el Editor de Unity)
    Vector3 currentTarget; // Almacena el objetivo actual al que se dirige (incluir� al jugador)
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
            if (currentDestination == destinations.Length - 1) // Si el destino actual es el �ltimo del array ...
            {
                currentDestination = 0; // ... volver� a empezar de nuevo
            }
            else // si no ...
            {
                currentDestination++; // ... continuar� con el siguiente destino
            }


            // animacion de caminar (0f)                                           // animacion de caminar (0f)
            anim.SetFloat("cursed-moviment", 0f);
        }

        if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollowPlayer) // Si el jugador est� dentro de la distancia especificada para empezar a seguirlo ...
        {
            currentTarget = player.transform.position; // ... asigna como objetivo actual al jugador
            // animacion de correr (0.5f)
            anim.SetFloat("cursed-moviment", 1f);
        }
        else // si no ...
        {
            currentTarget = destinations[currentDestination].transform.position;
            // animacion de caminar (0f)                                           // animacion de caminar (0f)
            anim.SetFloat("cursed-moviment", 0f); // ... contin�a con el destino que le corresponde (tambi�n controla que el jugador consiga escapar si corre m�s que el enemigo)
        }

        navMeshAgent.destination = currentTarget; // Asigna el objetivo al que debe ir, ya sea destino o jugador
    }
}