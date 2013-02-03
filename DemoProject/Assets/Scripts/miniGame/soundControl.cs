using UnityEngine;
using System.Collections;

public class soundControl : MonoBehaviour {

	public int playPosibility;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Random.Range(1, playPosibility) == 1)
		{
			var noisesResult = GameObject.FindGameObjectsWithTag("noise");
			var noise = noisesResult[Random.Range(0, noisesResult.Length)].audio;
			
			if(!noise.isPlaying) noise.Play();
		}
	}
}
