using UnityEngine;
using UnityEngine.SceneManagement;

public class musicController : MonoBehaviour{ 
   private static float CurrentLevel => SceneManager.GetActiveScene().buildIndex;

   private void Start(){
       
       playMainTheme();
   }
    
   public void playerDeath(){
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", 3 + CurrentLevel); 
   }

   public void playMainTheme(){
       Debug.Log("starting level music for level: " + (1+CurrentLevel));
       //music index start at 1, but level starts at 0
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", 1 + CurrentLevel); 
   }
}
