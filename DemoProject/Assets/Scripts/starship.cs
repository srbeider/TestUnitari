using UnityEngine;
using System.Collections;

public class starship : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(20 * Time.deltaTime, 0, 0, Space.World);
	}
}