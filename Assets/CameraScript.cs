using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update

     public Transform player;
private Vector3 offset = new Vector3(0,0,-10);
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + offset; // Camera follows the player with specified offset position
    }
}









