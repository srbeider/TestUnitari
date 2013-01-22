using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {
	
	public float offsetX;
	public float offsetY;
	public float fps;
	private float secondsToWait;
	private bool stop = true;
	
	// Use this for initialization
	void Start () {
		secondsToWait = 1/fps;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetAxis("Horizontal") != 0) {
			if (stop) {
				StartCoroutine("Animate");
				stop = false;
			}
		}
		else{
			StopCoroutine("Animate");
			renderer.material.SetTextureOffset("_MainTex", new Vector2(0, 0));
			stop = true;
		}
	}
	
	IEnumerator Animate(){
		yield return new WaitForSeconds(secondsToWait);
		var currentOffsetX = renderer.material.mainTextureOffset.x;
		var of = currentOffsetX + offsetX;
		if (of >= 0.88) {
			of = 0;
		}
		renderer.material.SetTextureOffset("_MainTex", new Vector2(of, offsetY));
		StartCoroutine("Animate");
	}
}
