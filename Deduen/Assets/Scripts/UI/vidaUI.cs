using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class vidaUI : MonoBehaviour
{
    public PlayerData playerData; // Arrastra aquí el objeto PlayerData desde el inspector
    [Header("Referencia al texto en el Canvas")]
    public TMP_Text textoUI; // Arrastra aquí el objeto TMP desde el inspector


    void Start()
    {
        // Validar que el texto está asignado
        if (textoUI == null)
        {
            Debug.LogError("No se ha asignado el componente TMP_Text en el inspector.");
            enabled = false; // Desactiva el script para evitar errores
            return;
        }

        // Mostrar valor inicial
        textoUI.text = "Vida(ps): " + playerData.vida;
    }

    void Update()
    {

    }
}
