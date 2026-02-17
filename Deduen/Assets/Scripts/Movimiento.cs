using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (horizontal == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (vertical == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (vertical == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        movement = new Vector2(horizontal, vertical);
    }

    void FixedUpdate()
    {
        movement = movement.normalized;
        rb.linearVelocity = movement * speed;
    }
}
