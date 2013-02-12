using UnityEngine;
using System.Collections;

public class LightPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(){
		if (Input.GetButton("A")) {
			Application.LoadLevel("scene2");	
		}
	}
}
