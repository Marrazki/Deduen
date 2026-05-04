using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public GameObject InvenoryMenu;
    private bool menuActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory") && menuActivated)
        {
            //Time.timeScale = 1f;  //Reanuda el tiempo
            InvenoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            //Time.timeScale = 0f;  //Para el tiempo
            InvenoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        // Aquí puedes agregar la lógica para añadir el item al inventario
        Debug.Log("Item agregado: " + itemName + " cantidad: " + quantity + " itemSprite: " + itemSprite);
    }
}
