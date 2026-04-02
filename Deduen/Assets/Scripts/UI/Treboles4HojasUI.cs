using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class Treboles4HojasUI : MonoBehaviour
{
    public Trebolario trebolario; // Arrastra aquí el objeto PlayerData desde el inspector
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
    }

    void Update()
    {
        textoUI.text = "X " + trebolario.trebolesCuatroHojas;

    }
}
