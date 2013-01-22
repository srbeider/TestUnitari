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
			var scale = renderer.material.GetTextureScale("_MainTex");
			if (hDelta < 0 && scale.x > 0) 
			{
				renderer.material.SetTextureScale("_MainTex", new Vector2(scale.x * -1, 0));
			}
			else if (hDelta > 0 && scale.x < 0) 
			{
				renderer.material.SetTextureScale("_MainTex", new Vector2(scale.x * -1, 0));
			}
			transform.Translate(new Vector3(-Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0));
		}
	}
}
