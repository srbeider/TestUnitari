using UnityEngine;
using System.Collections;

public class redLight : MonoBehaviour {

	public int offSeconds = 4;
	public int onSeconds = 1;
	public float velocity = 1.5F;
	public float maxIntensity = 1.5F;
	public float minIntensity = 0F;
	public state actualState = state.On;
	
	public enum state
	{
		Off,
		SwitchingOn,
		On,
		SwitchingOff
	}
	
	private float timer = 0;
	private float intensity = 0;
	
	// Use this for initialization
	void Start () {
		timer = 0;
		if(actualState == state.On || actualState == state.SwitchingOn)
		{
			intensity = maxIntensity;
		}
		else
		{
			intensity = minIntensity;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(actualState == state.Off && timer >= offSeconds)
		{
			actualState = state.SwitchingOn;
			timer = 0;
		}
		else if(actualState == state.SwitchingOn && intensity < maxIntensity)
		{
			intensity += velocity * Time.deltaTime;
		}
		else if(actualState == state.SwitchingOn && intensity >= maxIntensity)
		{
			intensity = maxIntensity;
			actualState = state.On;
			timer = 0;
		}
		else if(actualState == state.On && timer >= onSeconds)
		{
			actualState = state.SwitchingOff;
			timer = 0;
		}
		else if(actualState == state.SwitchingOff && intensity > minIntensity)
		{
			intensity -= velocity * Time.deltaTime;
		}
		else if(actualState == state.SwitchingOff && intensity <= minIntensity)
		{
			intensity = minIntensity;
			actualState = state.Off;
			timer = 0;
		}
		
		light.intensity = intensity;
	}
}