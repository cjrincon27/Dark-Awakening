using UnityEngine;

public class TriggerCinematica : MonoBehaviour
{
    public GameObject canvasObject; // Referencia al GameObject del canvas en la escena
    public float timeLimit = 6f; // Límite de tiempo en segundos
    private bool canvasActive = false;
    private bool canActivate = true; // Control para permitir la activación solo una vez
    private float timer = 0f;

    private void Update()
    {
        // Comprobar si el canvas está activo
        if (canvasActive)
        {
            // Incrementar el temporizador
            timer += Time.deltaTime;

            // Comprobar si se ha excedido el límite de tiempo
            if (timer >= timeLimit)
            {
                // Desactivar el canvas
                DeactivateCanvas();
            }
        }

        // Comprobar si se presionó la tecla Espacio
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

            // Deshabilitar la activación posterior
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
