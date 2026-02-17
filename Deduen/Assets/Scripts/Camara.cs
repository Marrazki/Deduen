using Unity.VisualScripting;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
