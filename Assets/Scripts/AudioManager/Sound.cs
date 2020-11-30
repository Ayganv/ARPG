using UnityEngine;
[System.Serializable]
public class Sound
{
    public string soundName;
    
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1;
    [Range(.1f, 3f)]
    public float pitch =1;

    public bool loop = false;
    
    [Range(0f, 1f)]
    public float spatialBlend = 0;

    public float minDistance = 10;
    public float maxDistance = 500;

    
    [HideInInspector]
    public AudioSource audioSource;
}
