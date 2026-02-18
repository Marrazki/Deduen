using UnityEngine;

public class Espada : Item
{
    public Animator animator; // Referencia al Animator para reproducir la animación de ataque
    private void Start()
    {
        daño = 5;
        rango = 1.5f;
        cooldown = 1f;
        anguloAtaque = 90f; // semicírculo
    }
    private void OnDrawGizmos()
    {
        if (transform.parent == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.parent.position, rango);

        // Línea frontal para referencia
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.parent.position,
            transform.parent.position + transform.up * rango);
    }
    protected override void Ataque()
    {
        // Reproducir animación
        if (animator != null)
            animator.SetTrigger("Ataque");

        // Ejecutar lógica de daño del padre
        base.Ataque();
    }
}
