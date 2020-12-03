using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        gameObject.GetComponent<SpawnStack>().NewChapter(gameObject.transform.position,"Go to the red box");
    }

    // Update is called once per frame
    void Update()
    {
        //while key is down
         if (Input.GetKey("w"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 1f);
        }

        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-1f, 0f, 0f);
        }
        if (Input.GetKey("s"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -1f);
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(1f, 0f, 0f);
        }
        //key press trigger once
        if(Input.GetKeyDown("q"))
        {
            gameObject.GetComponent<SpawnStack>().AddSpawn(gameObject.transform.position);
        }
        if(Input.GetKeyDown("e"))
        {
            gameObject.transform.position = gameObject.GetComponent<SpawnStack>().goBackToLatestSpawn().GetLocation();
        }
    }

}
