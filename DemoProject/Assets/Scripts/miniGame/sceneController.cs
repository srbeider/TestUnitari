using UnityEngine;
using System.Collections;

public class sceneController : MonoBehaviour {
	
	public int sparksPosibility;
	public int catchedObjects;
	
	private bool doorOpen;
	
	// Use this for initialization
	void Start ()
	{
		catchedObjects = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Sparks
		if(doorOpen)
		{
			if(Random.Range(1, sparksPosibility) == 1)
			{
				var sparksResult = GameObject.FindGameObjectsWithTag("sparks");
				sparksResult[Random.Range(0, sparksResult.Length)].GetComponent<sparks>().Spark();
			}
		}
	}
	
	public void setDoorOpen(bool isDoorOpen)
	{
		doorOpen = isDoorOpen;
	}
}
