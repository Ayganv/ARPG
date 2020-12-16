using UnityEngine;

public class musicController : MonoBehaviour{ 
    public float value = 1;
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
}
