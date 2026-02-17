using UnityEngine;
public class Espada : Item
{
    private void Start()
    {
        nombre = "Espada";
        id=1;
        daño=5;
        rango=1;
        cooldown = 1;
    }
    public override void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer <= 0)
            {
            Debug.Log("Espadazo! Daño: " + daño);
            cooldownTimer = cooldown;
        }
    }
}

