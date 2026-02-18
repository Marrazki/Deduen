using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [Header("Stats")]
    public int daño;
    public float rango;
    public float cooldown;
    public float anguloAtaque = 90f; // 90 = semicírculo

    [Header("Config")]
    public LayerMask capaEnemigos;

    protected float cooldownTimer;

    protected virtual void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            IntentarAtaque();
    }

    void IntentarAtaque()
    {
        if (cooldownTimer <= 0)
        {
            Ataque();
            cooldownTimer = cooldown;
        }
        else 
        {
            Debug.Log("¡Ataque en cooldown! Tiempo restante: " + cooldownTimer.ToString("F2") + "s");
        }
    }

    protected virtual void Ataque()
    {
        Debug.Log("¡Ataque realizado! Daño: " + daño);
        Vector2 centro = transform.parent.position;
        Collider2D[] enemigos = Physics2D.OverlapCircleAll(centro, rango, capaEnemigos);

        foreach (Collider2D enemigo in enemigos)
        {
            Vector2 direccion = (enemigo.transform.position - transform.parent.position).normalized;
            float angulo = Vector2.Angle(transform.up, direccion);

            if (angulo <= anguloAtaque)
            {
                Enemigo e = enemigo.GetComponent<Enemigo>();
                if (e != null)
                    e.RecibirDaño(daño);
            }
        }
    }
}
