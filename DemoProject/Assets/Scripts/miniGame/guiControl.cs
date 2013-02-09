using UnityEngine;
using System.Collections;

public class guiControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void ShowGUI()
	{
		if(!name.Equals("door")) renderer.enabled = true;
	}
	
	public void HideGUI()
	{
		if(!name.Equals("door")) renderer.enabled = false;
	}
	
	public void OnAction()
	{
		if(name.Equals("door"))
		{
			GetComponent<door>().ToogleDoor();
		}
	}
}
