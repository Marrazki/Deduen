using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    public float vida = 20;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    [Header("Parpadeo")]
    public Color colorDaño = Color.red;   // color al recibir daño
    public float duracionParpadeo = 0.1f;
    public int cantidadParpadeos = 3;

    [Header("Retroceso")]
    public float fuerzaRetroceso = 3f; // qué tan lejos lo empuja
    public float duracionRetroceso = 0.1f; // duración del retroceso

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            Debug.LogWarning("No se encontró SpriteRenderer en " + gameObject.name);
        if (rb == null)
            Debug.LogWarning("No se encontró Rigidbody2D en " + gameObject.name);
    }

    public void RecibirDaño(float cantidad, Vector2 direccion)
    {
        vida -= cantidad;
        Debug.Log("Vida restante: " + vida);

        if (spriteRenderer != null)
            StartCoroutine(ParpadeoDaño());

        if (rb != null)
            StartCoroutine(AplicarRetroceso(direccion));

        if (vida <= 0)
            Destroy(gameObject);
    }

    // Parpadeo al recibir daño
    private IEnumerator ParpadeoDaño()
    {
        Color colorOriginal = spriteRenderer.color;

        for (int i = 0; i < cantidadParpadeos; i++)
        {
            spriteRenderer.color = colorDaño;
            yield return new WaitForSeconds(duracionParpadeo);
            spriteRenderer.color = colorOriginal;
            yield return new WaitForSeconds(duracionParpadeo);
        }
    }

    // Retroceso
    private IEnumerator AplicarRetroceso(Vector2 direccion)
    {
        float tiempo = 0f;
        rb.linearVelocity = Vector2.zero; // reiniciamos velocidad

        // aplicamos impulso instantáneo
        rb.AddForce(direccion.normalized * fuerzaRetroceso, ForceMode2D.Impulse);

        // esperamos un corto periodo (duracionRetroceso)
        while (tiempo < duracionRetroceso)
        {
            tiempo += Time.deltaTime;
            yield return null;
        }

        // detenemos el movimiento
        rb.linearVelocity = Vector2.zero;
    }
}