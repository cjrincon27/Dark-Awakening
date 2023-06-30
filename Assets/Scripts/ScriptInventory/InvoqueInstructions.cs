using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvoqueInstructions : MonoBehaviour
{
    public Canvas canvasInstructions;
    public Canvas pauseCanvas;
    private bool canvasPause;
    private bool canvasInstructionsActive;
    
   

    // Start is called before the first frame update
    void Start()
    {
        canvasInstructions.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvasInstructionsActive)
            {
                canvasInstructions.gameObject.SetActive(false);
                canvasInstructionsActive = false;
            }
            else
            {
                canvasPause = !canvasPause;
            }
        }

        pauseCanvas.gameObject.SetActive(canvasPause && !canvasInstructionsActive);
        Time.timeScale = (canvasPause || canvasInstructionsActive) ? 0f : 1.0f;
    
    }

    public void ActivarCanvasInstructionsOnClick()
    {
        canvasInstructions.gameObject.SetActive(true);
        canvasInstructionsActive = true;

        pauseCanvas.gameObject.SetActive(false);
      
}
   
}






