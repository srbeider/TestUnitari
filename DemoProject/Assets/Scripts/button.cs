using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	
	public string Action = null;
	private Color pressed = new Color(0.75F, 0.75F, 0.75F);
	private Color focusIn = new Color(0.75F, 0F, 0F);
	private Color focusOut = new Color(0.25F, 0F, 0F);
	private fader faderScript;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = focusOut;
		faderScript = GameObject.Find("Fader").GetComponent<fader>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown(){
		
		renderer.material.color = pressed;
		switch(Action){
		case "exitGame":
			faderScript.nextScene = null;
			break;
		case "miniGame":
			faderScript.nextScene = "scene2";
			break;
		case "scene":
			faderScript.nextScene = "scene1";
			break;
		}
		faderScript.StartFadeOut();
	}
	
	void OnMouseEnter(){
		renderer.material.color = focusIn;
	}
	
	void OnMouseExit(){
		renderer.material.color = focusOut;
	}
}