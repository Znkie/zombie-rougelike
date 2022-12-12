using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabenemy;
    public float spawnTime;
<<<<<<< Updated upstream:Assets/Spawner.cs
    

=======
    private float spawnTimer;
    float timer = 10;
>>>>>>> Stashed changes:Assets/Scripts/Spawner.cs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
         timer -= Time.deltaTime;

        if (timer < 0)

        {
            GameObject tmpObj = Instantiate(prefabenemy);
            timer = 10;
        }
        }
    }
    void fixedUpdate()
    {
        {
         timer -= Time.deltaTime;

        if (timer < 0)

        {
            GameObject tmpObj = Instantiate(prefabenemy);
        }
        }
    }
}
