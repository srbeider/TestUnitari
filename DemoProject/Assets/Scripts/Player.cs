using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var hDelta = Input.GetAxis("Horizontal");
		if (hDelta != 0) {
			var scale = transform.localScale;
			if (hDelta < 0 && scale.x > 0) 
			{
				transform.localScale = new Vector3(scale.x * -1,scale.y,scale.z);
			}
			else if (hDelta > 0 && scale.x < 0) 
			{
				transform.localScale = new Vector3(scale.x * -1,scale.y,scale.z);
			}
			transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
		}
	}
}
