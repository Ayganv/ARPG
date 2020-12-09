using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint
{
    private Vector3 SpawnPosition;
    private Vector3 GoalPosition;
    private string message;
    public int Number;
    private static int successRadius = 3;

    
    //public static delegate bool successCheck();
    public bool successCheck(Vector3 Currentposition)
    {
        //Debug.Log(Vector3.Distance(Currentposition, GoalPosition));
        return Vector3.Distance(Currentposition, GoalPosition) < CheckPoint.successRadius;
    }
    public CheckPoint(Vector3 SpawnPosition, Vector3 GoalPosition, string Message, int Number)
    {
        this.SpawnPosition = SpawnPosition;
        this.GoalPosition = GoalPosition;
        this.message = Message;
        this.Number = Number;
    }
    public Vector3 GetSpawnPosition()
    {
        return this.SpawnPosition;
    }
    public string GetMessage()
    {
        return this.message;
    }
}
public class SpawnStack : MonoBehaviour
{
    public List<CheckPointSO> CheckPoints;
    private Stack<CheckPoint> Stack = new Stack<CheckPoint>();
    public GameObject SpawnTask;
    
    private void Update()
    {
        this.UpdateCheckPoint();

        //just for testing 
       /* if(Input.GetKeyDown("a"))
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-15,0,0);
        if(Input.GetKeyDown("s"))  
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-15);  
        if(Input.GetKeyDown("w"))  
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,15); 
        if(Input.GetKeyDown("d"))  
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(15,0,0); 
         */
        //just for testing


    }
    //add SO
    public void AddCheckPoint(CheckPointSO checkpoint)
    {
        this.Stack.Push(new CheckPoint(checkpoint.SpawnPosition, checkpoint.GoalPosition, checkpoint.Message, checkpoint.Number));
        this.WriteSpawnTask();
    }
    public void UpdateCheckPoint()
    {
        //if the spawn stack is empty, add the first checkpoint
        if(this.Stack.Count == 0)
        {
            this.AddCheckPoint(this.CheckPoints[0]);
        }
        if(this.getLatestSpawnData().successCheck(gameObject.transform.position))
        {
            //Debug.Log(this.getLatestSpawnData().Number);
            
            if(this.getLatestSpawnData().Number + 1 < this.CheckPoints.Count)
            {
                //Debug.Log(" current checkpoint");
                //Debug.Log(this.getLatestSpawnData().Number);
                this.AddCheckPoint(CheckPoints[this.getLatestSpawnData().Number + 1]);
                Debug.Log("Checkpoints count " +CheckPoints.Count);
                Debug.Log("Current checkpoint " +this.getLatestSpawnData().Number);
                
            }
            else
            {
               SpawnTask.GetComponent<Text>().text = "Congratulations, you have completed all tasks"; 
            }
     
        }

    }
    public void WriteSpawnTask()
    {
        SpawnTask.GetComponent<Text>().text = this.getLatestSpawnData().GetMessage();

    }
    
    public void ReSpawn()
    {
        gameObject.transform.position = getLatestSpawnData().GetSpawnPosition();
    }
    public CheckPoint getLatestSpawnData(){
        return this.Stack.Peek();
    }

}
