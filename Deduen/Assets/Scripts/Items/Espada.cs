using UnityEngine;

public class Espada : Item
{
    public LayerMask capaEnemigos; // LayerMask para 2D

    private void Start()
    {
        nombre = "Espada";
        id = 1;
        daño = 5;
        rango = 1f;
        cooldown = 1f;
    }

    private void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        Ataque();
    }

public override void Ataque()
{
    if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer <= 0)
    {
        Debug.Log("Espadazo! Daño: " + daño);

        // Tomar la posición del Player como centro
        Vector2 centroAtaque = (Vector2)(transform.parent.position + transform.up * rango);

        // Detectar enemigos 2D
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(centroAtaque, rango, capaEnemigos);

        foreach (Collider2D enemigo in enemigos)
        {
            Enemigo enemigoScript = enemigo.GetComponent<Enemigo>();
            if (enemigoScript != null)
            {
                enemigoScript.RecibirDaño(daño);
            }
        }

        cooldownTimer = cooldown;
    }
}


    // Visualizar el rango en Scene View
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 centroAtaque = (Vector2)(transform.parent.position + transform.up * rango);
        Gizmos.DrawWireSphere(centroAtaque, rango);
    }
}
