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
	
	public void ShowGUI(Vector3 renderPoint)
	{
		renderer.enabled = true;
		transform.position = renderPoint;
		print ("Showing GUI");
	}
	
	public void HideGUI()
	{
		renderer.enabled = false;
		print("Hiding GUI");
	}
}
