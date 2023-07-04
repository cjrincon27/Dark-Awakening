using UnityEngine;

public class TriggerCinematica : MonoBehaviour
{
    public GameObject canvasObject; // Reference to the canvas GameObject in the scene
    public float timeLimit = 6f; // Time limit in seconds
    private bool canvasActive = false;
    private float timer = 0f;

    private void Update()
    {
        // Check if the canvas is active
        if (canvasActive)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the time limit has been exceeded
            if (timer >= timeLimit)
            {
                // Deactivate the canvas
                canvasObject.SetActive(false);
                canvasActive = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the canvas
            canvasObject.SetActive(true);
            canvasActive = true;

            // Reset the timer
            timer = 0f;
        }
    }
}
