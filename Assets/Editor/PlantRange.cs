using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (PlantEnemy))]
public class PlantRange : Editor {

    void OnSceneGUI() {
        PlantEnemy fow = (PlantEnemy)target;
        Handles.color = Color.red;
        Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.damageRadius);
        
    }
}
