using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	
	public float speed = 10F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		var axisX = -Input.GetAxisRaw("Vertical");
		var axisY = Input.GetAxisRaw("Horizontal");
		transform.Rotate(axisX, axisY, 0);
	}
}
