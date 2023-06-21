using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public float normalHeight, crouchHeight;
   
    public CharacterController PlayerHeight;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        // Lock cursor = Cursos bloqueado
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes = Estamos en tierra, por lo que recalcular la dirección de movimiento basado en ejes
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        
        // Press Left Shift to run = Presione "Shift" para correr
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below = Aplicar la gravedad. "gravity" se multiplica por "deltaTime" dos veces (una aquí, y otra abajo)
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied = cuando moveDirection se multiplica por deltaTime). Esto se debe a que la gravedad debe aplicarse
        // as an acceleration (ms^-2) = como aceleración (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller = Mueve el controllador
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation = Rotación del jugador y la  camara
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        
        // Player Crouching = El jugador se agacha
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            PlayerHeight.height = crouchHeight;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            PlayerHeight.height = normalHeight;
        }
    }
}
