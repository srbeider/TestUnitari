using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {
	
	public float onIntensity = 1.5F;
	public float offIntensity = 0F;
	public state ActualState;
	
	public enum state
	{
		On,
		Off
	}
	
	// Use this for initialization
	void Start () {
		if(ActualState == state.Off)
		{
			light.intensity = offIntensity;
		}
		else
		{
			light.intensity = onIntensity;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SwitchOn()
	{
		light.intensity = onIntensity;
		ActualState = state.On;
	}
	
	public void SwitchOff()
	{
		light.intensity = offIntensity;
		ActualState = state.Off;
	}
}
