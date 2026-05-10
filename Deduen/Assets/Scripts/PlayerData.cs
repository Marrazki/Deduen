using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int vida, vidaMax, aura, aurilla;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vida = 10;
        vidaMax = 10;
        aura = 1;
        aurilla = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            RecibirDanio(2); // Simula recibir 2 puntos de daño al presionar 'H'
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GanarAurilla(5); // Simula ganar 5 aurilla al presionar 'J'
        }
    }
    public void RecibirDanio(int daño)
    {
        vida -= daño;
        Debug.Log("¡Has recibido " + daño + " de daño! Vida restante: " + vida);
        if (vida <= 0)
        {
            Morir();
        }
    }
    public void Curar(int ps)
    {
        if (vida + ps >= vidaMax)
        {
            vida = vidaMax;
             Debug.Log("¡Tu vida está al máximo! Vida restante: " + vida);
        }
        else
        {
            vida += ps;
            Debug.Log("¡Has recibido " + ps + " de vida! Vida restante: " + vida);
        }
    }
    public void GanarAurilla(int cantidadAurilla)
    {
        aurilla += cantidadAurilla;
        Debug.Log("¡Has ganado " + cantidadAurilla + " aurilla! Total aurilla: " + aurilla);
        VerificarNivel();
    }
    void VerificarNivel()
    {
        int aurillaNecesaria = aura * 10; // Ejemplo: cada nivel requiere 10 aurilla más que el anterior
        if (aurilla >= aurillaNecesaria)
        {
            aura++;
            vida = vida + 3;
            vidaMax = vidaMax + 3;
            aurilla -= aurillaNecesaria; // Restar el aurilla necesario para subir de nivel
            Debug.Log("¡Has subido al nivel " + aura + "! aurilla restante: " + aurilla);
        }
    }
    void Morir()
    {
        Debug.Log("¡Has muerto! Reiniciando juego...");
        // Aquí podrías agregar lógica para reiniciar el nivel, mostrar una pantalla de muerte, etc.

    }
}
