using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (EnemyScript))]
public class ThreatCircle : Editor {

    void OnSceneGUI() {
        EnemyScript fow = (EnemyScript)target;
        Handles.color = Color.white;
        Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        
        
    }

}