using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    public GameObject rotedPlayer;
    public Sprite spriteArriba;
    public Sprite spriteAbajo;
    public Sprite spriteDerecha;
    public Sprite spriteIzquierda;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        {
            // Obtener el componente SpriteRenderer del GameObject
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Validar que el componente existe
            if (spriteRenderer == null)
            {
                Debug.LogError("No se encontró un SpriteRenderer en este GameObject.");
                enabled = false; // Desactivar el script para evitar errores
                return;
            }

            // Validar que el sprite nuevo está asignado
            if (spriteAbajo == null)
            {
                Debug.LogWarning("No se asignó un sprite nuevo en el Inspector.");
                return;
            }

            // Cambiar el sprite
            spriteRenderer.sprite = spriteAbajo;
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //EVITAR DIAGONALES
        //if (horizontal != 0)
        //{
        //    vertical = 0;
        //}

        if (horizontal == 1)
        {
            rotedPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);

            spriteRenderer.sprite = spriteDerecha;
        }
        if (horizontal == -1)
        {
            rotedPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = spriteIzquierda;
        }
        if (vertical == 1)
        {
            rotedPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = spriteArriba;
        }
        if (vertical == -1)
        {
            rotedPlayer.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = spriteAbajo;
        }
        movement = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        movement = movement.normalized;
        rb.linearVelocity = movement * speed;
    }
}
