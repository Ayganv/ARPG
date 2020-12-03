using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn
{
    private Vector3 position;
    private string message;
    public Spawn(Vector3 position, string message)
    {
        this.position = position;
        this.message = message;
    }
    public Vector3 GetLocation()
    {
        return this.position;
    }
    public string GetMessage()
    {
        return this.message;
    }
}
public class SpawnStack : MonoBehaviour
{
    // Start is called before the first frame update
    

    private Stack<Spawn> Stack = new Stack<Spawn>();
    public GameObject SpawnTask;
    public string objective; 
    

    public void AddSpawn(Vector3 position)
    {
        this.Stack.Push(new Spawn(position, $"spawn {this.Stack.Count}"));
        this.WriteSpawnTask();
    }
    public void WriteSpawnTask()
    {
        SpawnTask.GetComponent<Text>().text = this.objective + "\n" + this.getLatestSpawnData().GetMessage();

    }
    public Spawn goBackToLatestSpawn(){
        //SpawnTask.GetComponent<Text>().text = this.Stack.Peek().GetMessage();
        return this.Stack.Peek();
    }
    public Spawn getLatestSpawnData(){
        return this.Stack.Peek();
    }
    public void NewChapter(Vector3 position, string objective){
        this.Stack.Clear();
        this.AddSpawn(position);  
        this.objective = objective;
        this.WriteSpawnTask();
    }

}
