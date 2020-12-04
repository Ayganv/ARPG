using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Enemy))]
public class ThreatCircle : Editor {

    void OnSceneGUI() {
        Enemy fow = (Enemy)target;
        Handles.color = Color.white;
        Handles.DrawWireArc (fow.transform.position, Vector3.up, Vector3.forward, 360, fow.ViewRadius);
    }
}