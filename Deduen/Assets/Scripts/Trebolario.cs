using System.Collections;
using UnityEngine;

public class Trebolario : MonoBehaviour
{
    public int treboles;
    public int trebolesCuatroHojas;
    public int trebolesPlantados;
    public float tiempoFarmeo = 3; // Tiempo en segundos para generar tréboles automáticamente

    [Header("Imagenes UI")]
    public GameObject imagenTrebol4Hojas;
    [SerializeField] private GameObject padreTreboles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treboles = 0;
        trebolesCuatroHojas = 0;
        trebolesPlantados = 1;

        StartCoroutine(GenerarTreboles());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlantarTrebol();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            ObtenerTrebol();
        }
    }
    public void PlantarTrebol()
    {
        if (trebolesCuatroHojas > 0)
        {
            Debug.Log("Plantaste un trébol");
            trebolesPlantados++;
            trebolesCuatroHojas--;
            // Instanciar la imagen del trébol de cuatro hojas en el padre
            float xPos = Random.Range(-170f, 170f); // Ajusta el rango según tus necesidades
            float yPos = Random.Range(-170f, 170f); // Ajusta el rango según tus necesidades
            GameObject nuevoTrebol = Instantiate(imagenTrebol4Hojas, new Vector3(xPos, yPos, 0), Quaternion.identity);
            nuevoTrebol.transform.SetParent(padreTreboles.transform, false);
        }
    }
    public void ObtenerTrebol()
    {
        int random = Random.Range(0, 100);
        if (random == 54)
        {
            Debug.Log("Obtuviste un trébol de cuatro hojas");
            trebolesCuatroHojas++;
        }
        else 
        {
            Debug.Log("Obtuviste un trébol");
            treboles++;
        }
        Debug.Log("Treboles: " + treboles);
        Debug.Log("Treboles de cuatro hojas: " + trebolesCuatroHojas);
    }
    IEnumerator GenerarTreboles()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoFarmeo); // Cada x segundos

            for (int i = 0; i < trebolesPlantados; i++)
            {
                ObtenerTrebol();
            }
        }
    }
}
