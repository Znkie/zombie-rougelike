using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BefallenPeasant : MonoBehaviour
{
    public float befallenSpeed;
    int befallenDirect = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (befallenDirect ==1)
        {
            transform.Translate(befallenSpeed * Time.deltaTime, 0f, 0f);  //makes player run Right 
        }

        if (befallenDirect ==0)
        {
            transform.Translate(-befallenSpeed * Time.deltaTime, 0f,0f);  //makes player run Right 
        }

       
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.tag == "Turntrigger")
        {
            if (befallenDirect ==1)
            {
                Debug.Log("turnlef");
                befallenDirect = 0;   
            }

            if (befallenDirect ==0) 
            {
                Debug.Log("turnrit");
                befallenDirect = 1;   
            }
        }
     }


}
