using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    private const float chaseSpeed = 4f;
    private float chaseRotationSpeed = 5f;
    private const float detectionRange = 50f;
    private const float chaseRange = 12f;

    private float patrolSpeed = 3f;
    private float patrolArrivalDistance = 0.2f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange && distance <= chaseRange)
        {
            ChasePlayer(); // Si el jugador esta dentro del rango lo persigue
        }
        else
        {
            Patrol(); // Si el jugador está fuera de rango, el enemigo patrulla
        }
    }

    private void ChasePlayer()
    {

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * chaseSpeed * Time.deltaTime;

        // Rota hacia el jugador
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, chaseRotationSpeed * Time.deltaTime);
    }


    private void Patrol()
    {
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime;

        // Comprueba si el enemigo ha llegado al waypoint actual
        float distanceToWaypoint = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distanceToWaypoint <= patrolArrivalDistance)
        {
            currentWaypointIndex++;

            // Si el enemigo llega al final de la lista, volvemos al primer waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
