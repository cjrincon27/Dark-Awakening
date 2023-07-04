using UnityEngine;

public class TriggerCinematica : MonoBehaviour
{
    public GameObject canvasObject; // Referencia al GameObject del canvas en la escena
    public float timeLimit = 6f; // L�mite de tiempo en segundos
    private bool canvasActive = false;
    private bool canActivate = true; // Control para permitir la activaci�n solo una vez
    private float timer = 0f;

    private void Update()
    {
        // Comprobar si el canvas est� activo
        if (canvasActive)
        {
            // Incrementar el temporizador
            timer += Time.deltaTime;

            // Comprobar si se ha excedido el l�mite de tiempo
            if (timer >= timeLimit)
            {
                // Desactivar el canvas
                DeactivateCanvas();
            }
        }

        // Comprobar si se presion� la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Desactivar el canvas
            if (canvasActive)
            {
                DeactivateCanvas();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canActivate && other.CompareTag("Player"))
        {
            // Activar el canvas
            ActivateCanvas();

            // Deshabilitar la activaci�n posterior
            canActivate = false;
        }
    }

    private void ActivateCanvas()
    {
        canvasObject.SetActive(true);
        canvasActive = true;
        timer = 0f;
    }

    private void DeactivateCanvas()
    {
        canvasObject.SetActive(false);
        canvasActive = false;
    }
}
