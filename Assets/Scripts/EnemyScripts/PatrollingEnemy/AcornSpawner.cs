using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    public float timeBetweenShots;
    private float timer;

    public GameObject acorn;
    
    void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }

    public void Spawn()
    {
        if (timer >= timeBetweenShots)
        {
            Instantiate(acorn, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
