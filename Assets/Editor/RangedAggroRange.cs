using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (RangedEnemy))]
public class RangedAggroRange : Editor {

    void OnSceneGUI() {
        RangedEnemy fow = (RangedEnemy)target;
        Handles.color = Color.white;
        Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        
    }

    

    

}