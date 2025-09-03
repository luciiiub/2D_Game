
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("COMPONENTS")]
    public Rigidbody2D rb;   // Componente Rigidbody2D para el movimiento
    public SpriteRenderer sr;  // Componente SpriteRenderer para voltear el sprite
    public Animator anim;       // Controlador de animaciones

    [Header("CONFIGURACION PERSONAJE")]
    public int vida = 3;      // Vidas del personaje
    public float velocidad = 6.0f;  // Velocidad normal de movimiento
    public float aumentoVelocidad = 2.0f; // Cuanto aumenta al correr
    public float impulso = 5.0f;   // Fuerza del salto

    [Header("DEBUG")]
    public bool permitirSalto = false;   // Indica si puede saltar
    public bool permitirDobleSalto = false;  // Indica si puede hacer doble salto

    void Update()
    {
        movimiento(); // Ejecuta la logica de movimiento
        salto();  // Ejecuta la logica de salto
    }

    void movimiento()
    {
        // Si se presiona Shift (Fire3 por defecto)
        if (Input.GetButtonDown("Fire3"))
        {
            anim.SetBool("isRunning", true);  // Activa animacion de correr
            velocidad += aumentoVelocidad;  // Aumenta la velocidad
        }

        // Si se suelta Shift
        if (Input.GetButtonUp("Fire3"))
        {
            anim.SetBool("isRunning", false); // Desactiva animacion de correr
            velocidad -= aumentoVelocidad;  // Resta velocidad extra
        }

        // Movimiento horizontal
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);

        // Si no se esta moviendo
        if (rb.velocity.x == 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }

        // Si se mueve a la derecha
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isWalking", true);
            sr.flipX = false; // Mira a la derecha
        }

        // Si se mueve a la izquierda
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true);
            sr.flipX = true; // Mira a la izquierda
        }
    }

    void salto()
    {
        // Doble salto
        if (Input.GetButtonDown("Jump") && permitirDobleSalto)
        {
            rb.velocity = Vector2.zero;  // Resetea la velocidad antes del salto
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            permitirDobleSalto = false;    // Solo se permite una vez
        }

        
        if (Input.GetButtonDown("Jump") && permitirSalto) // Salto normal
        {
            rb.AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
            Invoke("PermitirDobleSalto", 0.1f);   // Habilita el doble salto tras un pequeño retraso
        }
    }

    // Activa el doble salto
    private void PermitirDobleSalto()
    {
        permitirDobleSalto = true;
    }

    // Mientras este tocando el suelo, se permite el salto
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            permitirSalto = true;
            permitirDobleSalto = false;
        }
    }

    // Al salir del suelo, se desactiva el salto
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            permitirSalto = false;
        }
    }
}




