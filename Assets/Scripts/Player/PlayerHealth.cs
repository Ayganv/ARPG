using Player;
using Units;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : UnitHealth{

    public override void Update(){
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.K)) Health = 0;

        base.Update(); 
    }
}