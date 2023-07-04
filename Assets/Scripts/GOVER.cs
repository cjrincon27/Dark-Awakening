using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOVER : MonoBehaviour
{
    public GameObject canvasObject; // Referencia al GameObject del canvas en la escena
    public int requiredSpacePresses = 5; // N�mero de veces que se debe presionar la barra espaciadora
    public float timeLimit = 6f; // L�mite de tiempo en segundos
    private bool canvasActive = false;
    private int spacePresses = 0;
    private float timer = 0f;

    private void Update()
    {
        // Verificar si el canvas est� activo
        if (canvasActive)
        {
            // Incrementar el temporizador
            timer += Time.deltaTime;

            // Verificar si se ha excedido el tiempo l�mite
            if (timer >= timeLimit)
            {
                // Ir a otra escena
                SceneManager.LoadScene("GAMEOVER");
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
}
