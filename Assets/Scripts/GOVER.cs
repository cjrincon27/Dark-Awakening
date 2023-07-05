using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOVER : MonoBehaviour
{
    public GameObject canvasObject; // Referencia al GameObject del canvas en la escena
    public int requiredSpacePresses = 5; // Número de veces que se debe presionar la barra espaciadora
    public float timeLimit = 6f; // Límite de tiempo en segundos
    public bool useOriginalPosition = true; // Indica si se utilizará la posición original del objeto
    public Vector3 manualResetPosition; // Posición de reposicionamiento manual

    private bool canvasActive = false;
    private int spacePresses = 0;
    private float timer = 0f;
    private Vector3 originalPosition; // Variable para almacenar la posición original del objeto

    private void Start()
    {
        // Almacenar la posición original del objeto al inicio
        if (useOriginalPosition)
        {
            originalPosition = transform.position;
        }
    }

    private void Update()
    {
        // Verificar si el canvas está activo
        if (canvasActive)
        {
            // Incrementar el temporizador
            timer += Time.deltaTime;

            // Verificar si se ha excedido el tiempo límite
            if (timer >= timeLimit)
            {
                // Ir a otra escena
                SceneManager.LoadScene("GAMEOVER");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // Verificar si se ha presionado la barra espaciadora
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    spacePresses++;

                    // Verificar si se han alcanzado las veces requeridas
                    if (spacePresses >= requiredSpacePresses)
                    {
                        // Desactivar el canvas
                        canvasObject.SetActive(false);
                        canvasActive = false;

                        // Reposicionar al objeto
                        ResetPosition();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activar el canvas
            canvasObject.SetActive(true);
            canvasActive = true;

            // Reiniciar las variables
            spacePresses = 0;
            timer = 0f;
        }
    }

    private void ResetPosition()
    {
        // Reposicionar el objeto
        if (useOriginalPosition)
        {
            transform.position = originalPosition;
        }
        else
        {
            transform.position = manualResetPosition;
        }
    }
}
