using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CheckPointSO", order = 1)]
public class CheckPointSO : ScriptableObject
{
    // Start is called before the first frame update
    public string Message;
    public int Number;
    public Vector3 SpawnPosition;
    public Vector3 GoalPosition;
}
