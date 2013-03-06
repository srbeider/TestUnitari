using UnityEngine;
using System.Collections;

public class scene1Behaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find ("GameController").GetComponent<gameControllerScripts>().miniGameResolved){
			RenderSettings.ambientLight = Color.white;
		}
	}
}
