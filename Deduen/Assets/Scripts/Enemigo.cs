using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float vida = 20;

    public void RecibirDaño(float cantidad)
    {
        vida -= cantidad;
        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
