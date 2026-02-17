using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected string nombre;
    [SerializeField] protected int id;
    [SerializeField] protected int daño;
    [SerializeField] protected float rango;
    [SerializeField] protected float cooldown;

    protected float cooldownTimer = 0f;

    protected virtual void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        Ataque();
    }
    public virtual void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer <= 0)
        {
            Debug.Log("Ataque con " + nombre + " | Daño: " + daño);
            cooldownTimer = cooldown;
        }
    }
}
