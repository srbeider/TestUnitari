using UnityEngine;
using System.Collections;

public class sceneController : MonoBehaviour {
	
	public int sparksPosibility;
	public int catchedObjects;
	public int resolvedObjects;
	
	public string cachedId;
	public string collisionId;
	
	public bool isSceneActive;
	
	private bool doorOpen;
	
	// Use this for initialization
	void Start ()
	{
		catchedObjects = 0;
		resolvedObjects = 0;
		isSceneActive = true;
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
	
	public void ExitScene()
	{
		isSceneActive = false;
		var doorScript = GameObject.Find ("door").GetComponent<door>();
		if(doorScript.ActualState == door.state.Open)
		{
			doorScript.ToogleDoor();
		}
		
		GameObject.Find("dot").renderer.enabled = false;
		
		var faderScript = GameObject.Find ("Fader").GetComponent<fader>();
		faderScript.nextScene = "scene1";
		faderScript.StartFadeOut();
	}
}
