using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    /*
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    */
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public bool CanJUmp;

    public float gravityValue = -9.81f;
    public float rotationSpeed = 5.0f;

    public float x, y;
    public Animator anim;
    public Rigidbody rb;



    /*
    private float moveHorizontal;
    private float moveVertical;
    */

    void Start()
    {

        // Obtenemos el CharacterController y el Animator al inicio del juego
        //controller = GetComponent<CharacterController>();
        CanJUmp = false;

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * playerSpeed);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

       // transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
       // transform.Translate(0, 0, y * Time.deltaTime * playerSpeed);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (CanJUmp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("salte0", true);
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
            anim.SetBool("GroundT", true);

        }
        else
        {
            ImFalling();
        }

        /*
        // Obtener la entrada del usuario para movimiento horizontal y vertical
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // Rotar y mover al jugador en base a la entrada del usuario
        transform.Rotate(0, moveHorizontal * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, moveVertical * Time.deltaTime * playerSpeed);

        // Actualizar los parámetros de la animación
        anim.SetFloat("VelX", moveHorizontal);
        anim.SetFloat("VelY", moveVertical);

        // Verificar si el jugador está en el suelo
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            // Resetear la velocidad vertical si el jugador está en el suelo
            playerVelocity.y = 0f;
        }

        // Mover al jugador en base a la entrada del usuario
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Orientar al jugador hacia la dirección de movimiento
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Permitir que el jugador salte si está en el suelo
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // Calcular la velocidad necesaria para el salto y aplicarla
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        // Aplicar la gravedad al jugador
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        */

    }

    public void ImFalling() {
        anim.SetBool("GroundT", false);
        anim.SetBool("salte", false );
    }
}
