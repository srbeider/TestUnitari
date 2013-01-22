using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	
	public string Action = null;
	private Color pressed = new Color(0.75F, 0.75F, 0.75F);
	private Color entered = new Color(0.75F, 0F, 0F);
	private Color exited = new Color(0.25F, 0F, 0F);
	
	// Use this for initialization
	void Start () {
		renderer.material.color = exited;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		
		renderer.material.color = pressed;
		switch(Action){
		case "exitGame":
			print ("EXITING");
			Application.Quit();
			break;
		case "miniGame":
			print("MINIGAME");
			break;
		case "scene":
			print("SCENE");
			break;
		}
	}
	
	void OnMouseEnter(){
		renderer.material.color = entered;
	}
	
	void OnMouseExit(){
		renderer.material.color = exited;
	}
}