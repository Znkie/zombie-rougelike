using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    int allyHealth = 10;
    int jumpCount = 0;
    int jumpMax = 1;
    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;

    // Use this for initialization
    void Start()
    {
        Debug.Log(jumpCount);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run Right 
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0f,0f);  //makes player run Right 
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < jumpMax)  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            jumpCount += 1;
            Debug.Log(jumpCount+" jump");
        }
        
    }
    //Resets Arial mobility on touching the ground
    void ResetAerial()
    {
        jumpCount = 0;
        Debug.Log(jumpCount + " Reset");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log (jumpCount);
        if (other.gameObject.tag == "Ground")
        {
            ResetAerial();
        }
        {
            Debug.Log(allyHealth);
            if (other.gameObject.tag == "Enemy Hurtbox")
            {
                allyHealth -= 1;
                if (allyHealth == 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
