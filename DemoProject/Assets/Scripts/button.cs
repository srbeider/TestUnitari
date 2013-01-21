using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	
	public string Action = null;
	private Color pressed = new Color(160, 160, 160);
	private Color entered = new Color(160, 0, 0);
	private Color exited = new Color(50, 0, 0);
	
	// Use this for initialization
	void Start () {
		renderer.material.color = exited;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		
		renderer.material.color = pressed;
		print("PRESSED!");
		switch(Action){
		case "exitGame":
			print ("EXITING");
			Application.Quit();
			break;
		}
	}
	
	
	
	void OnMouseEnter(){
		print("ENTERED!");
		renderer.material.color = entered;
	}
	
	void OnMouseExit(){
		print("EXITED!");
		renderer.material.color = exited;
	}
}
