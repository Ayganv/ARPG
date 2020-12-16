using UnityEngine;

public class musicController : MonoBehaviour{ 
   public float value = 1;
   static float currentLevel = 0;

   public static float CurrentLevel{
       set => currentLevel = value;
   }
   private void Start(){
           
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", value); 
   }

   public void playLevel2(){
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", 2); 
   }
    
   public void playerDeath(){
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", 3); 
   }

   public void playerDeath2(){
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", 4); 
   }

   public void playMainTheme(float musicSequence){
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("musicSequenceParameter", musicSequence + currentLevel); 
   }
}
