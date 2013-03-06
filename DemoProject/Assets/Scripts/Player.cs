using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Y")) {
			transform.FindChild("Flashlight").gameObject.SetActive(!transform.FindChild("Flashlight").gameObject.activeSelf);
		}
		
		var hDelta = Input.GetAxis("Horizontal");
		if (hDelta != 0) {
			var scale = transform.localScale;
			if (hDelta < 0 && scale.x > 0) 
			{
				transform.localScale = new Vector3(scale.x * -1,scale.y,scale.z);
				transform.FindChild("Flashlight").rotation = Quaternion.Euler(0, 90, 0);
			}
			else if (hDelta > 0 && scale.x < 0) 
			{
				transform.localScale = new Vector3(scale.x * -1,scale.y,scale.z);
				transform.FindChild("Flashlight").rotation = Quaternion.Euler(0, 256, 0);
			}
			transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
		}
	}
}
