using UnityEngine;

public class CanvasSombrero : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private bool abierto = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (abierto)
                Cerrar();
            else
                Abrir();
        }
    }

    void Abrir()
    {
        canvasGroup.alpha = 1f; // Opacidad (0 = invisible, 1 = sólido)
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        abierto = true;
    }

    void Cerrar()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        abierto = false;
    }
}
