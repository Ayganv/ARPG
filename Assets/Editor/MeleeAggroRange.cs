using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MeleeEnemy))]
public class MeleeAggroRange : Editor {

    void OnSceneGUI() {
        MeleeEnemy fow = (MeleeEnemy)target;
        Handles.color = Color.white;
        Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
        
    }
}
