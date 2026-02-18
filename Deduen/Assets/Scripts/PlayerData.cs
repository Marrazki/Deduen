using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int vida, vidaMax, lvl, xp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = 10;
        vidaMax = 10;
        lvl = 1;
        xp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RecibirDaño(2); // Simula recibir 2 puntos de daño al presionar 'H'
        }
            if (Input.GetKeyDown(KeyCode.J))
        {
                GanarXP(5); // Simula ganar 5 XP al presionar 'J'
        }
    }
    public void RecibirDaño(int daño)
    {
        vida -= daño;
        Debug.Log("¡Has recibido " + daño + " de daño! Vida restante: " + vida);
        if (vida <= 0)
        {
            Morir();
        }
    }
    public void GanarXP(int cantidadXp)
    {
        xp += cantidadXp;
        Debug.Log("¡Has ganado " + cantidadXp + " XP! Total XP: " + xp);
        VerificarNivel();
    }
    void VerificarNivel()
    {
        int xpNecesaria = lvl * 10; // Ejemplo: cada nivel requiere 10 XP más que el anterior
        if (xp >= xpNecesaria)
        {
            lvl++;
            vida = vida + 3;
            vidaMax = vidaMax + 3;
            xp -= xpNecesaria; // Restar el XP necesario para subir de nivel
            Debug.Log("¡Has subido al nivel " + lvl + "! XP restante: " + xp);
        }
    }
    void Morir()
    {
        Debug.Log("¡Has muerto! Reiniciando juego...");
        // Aquí podrías agregar lógica para reiniciar el nivel, mostrar una pantalla de muerte, etc.

    }
}
