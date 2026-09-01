using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;

    public Transform lastPlatform;  // refrence to our last platform
    Vector3 lastPosition;          // for storing the last position
    Vector3 newPos;               // for storing the new position



    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;


        StartCoroutine(spawnPlatforms());
        
    }

    // Update is called once per frame
    void Update()
    {







        // if (Input.GetKey(KeyCode.Space))
        // {
        //     spawnPlatforms();
        // }
    }


    IEnumerator spawnPlatforms()
    {
        while(!stop)
        {

        generatePosition();
        Instantiate(platform, newPos, Quaternion.identity);
        lastPosition = newPos;

        yield return new WaitForSeconds(0.1f);

        }





    }


    // void spawnPlatforms()
    // {
    //     generatePosition();

    //     Instantiate(platform, newPos, Quaternion.identity);

    //     lastPosition = newPos;

    // }


    void generatePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2); // 2 is exclusive

        if (rand > 0){
            newPos.x  += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
}
