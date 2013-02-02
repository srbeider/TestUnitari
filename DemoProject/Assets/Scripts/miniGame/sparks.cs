using UnityEngine;
using System.Collections;

public class sparks : MonoBehaviour {
	
	float timer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(particleSystem.light.intensity > 0)
		{
			timer += Time.deltaTime;
		}
		
		if(timer > particleSystem.duration) particleSystem.light.intensity = 0;
	}
	
	public void Spark()
	{
		timer = 0F;
		particleSystem.Stop();
		particleSystem.Play();
		particleSystem.light.intensity = 2;
	}
}