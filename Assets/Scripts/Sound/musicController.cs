using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    
    [FMODUnity.EventRef]
    public string fmodEvent;
    
    [SerializeField] 
    private float Init, InGame;

    [SerializeField] 
    private float InGame2;

    [SerializeField]
    private float musicSequenceParameter;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
        
    }

    // Update is called once per frame
    void Update()
    {
        instance.setParameterByName("Init", Init);
        instance.setParameterByName("InGame", InGame);
        instance.setParameterByName("InGame2", InGame2);
        instance.setParameterByName("musicSequenceParameter", musicSequenceParameter);
        
    }
}
