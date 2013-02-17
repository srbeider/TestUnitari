using UnityEngine;
using System.Collections;

public class guiControl : MonoBehaviour {
	
	private sceneController controller;
	
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.Find("ScriptsController").GetComponent<sceneController>();
		if(!name.Equals("door"))
		{
			renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ShowGUI()
	{
		if(!name.Equals("door"))
		{
			if(name.Contains("sparks") || (name.Contains("board") && controller.catchedObjects == 0))
			{
				renderer.enabled = true; 
			}
		}
	}
	
	public void HideGUI()
	{
		if(!name.Equals("door"))
		{
			renderer.enabled = false; 
		}
	}
	
	public void OnActionA()
	{
		if(name.Equals("door"))
		{
			GetComponent<door>().ToogleDoor();
		}
		else if(name.StartsWith("board"))
		{
			GameObject.Find(name.Replace("_wire",string.Empty)).GetComponent<boardElement>().Catch();
		}		
	}
	
	public void OnActionB()
	{
		if(name.Equals("door"))
		{
			
		}
		else if(name.StartsWith("board"))
		{
			GameObject.Find(name.Replace("_wire",string.Empty)).GetComponent<boardElement>().Drop();
		}
	}
}
