using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{

    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ReviveButtom()
    {
        GameObject.FindWithTag("Player").SetActive(true);
        FindObjectOfType<Death>().Health = 100;
        gameover.SetActive(false);
    }

    
}
