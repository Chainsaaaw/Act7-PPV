using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;     // Velocidad de movimiento del personaje.
    public float jumpForce = 10.0f;    // Fuerza de salto del personaje.
    public Transform groundCheck;       // Transform para comprobar si el personaje está en el suelo.
    public LayerMask groundLayer;       // Capa que representa el suelo.

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Comprobar si el personaje está en el suelo.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Mover el personaje.
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Saltar si el personaje está en el suelo y se presiona la tecla de salto (por ejemplo, la barra espaciadora).
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
