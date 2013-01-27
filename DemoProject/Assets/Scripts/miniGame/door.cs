using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	
	public float velocity = 5F;
	public float ClosedAngle = 0F;
	public float OpenAngle = 90F;
	public state ActualState = state.Closed;
	public enum state
	{
		Closed,
		Open
	}
	
	// Use this for initialization
	void Start () {
		if(ActualState == state.Open)
		{
			SwitchLightOn();
		}
		else
		{
			SwitchLightOff();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Closed
		if(ActualState == state.Closed)
		{
			var target = Quaternion.Euler(0, ClosedAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * velocity);
		}
		//Open
		else if(ActualState == state.Open)
		{
			var target = Quaternion.Euler(0, OpenAngle, 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * velocity);
		}
	}
	
	void OnMouseDown()
	{
		if(ActualState == state.Open)
		{
			ActualState = state.Closed;
			SwitchLightOff();
		}
		else if(ActualState == state.Closed)
		{
			ActualState = state.Open;
			SwitchLightOn();
		}
	}
	
	private void SwitchLightOn()
	{
		var lights = GameObject.FindGameObjectsWithTag("light");
		foreach(var light in lights) light.GetComponent<light>().SwitchOn();
	}
	
	private void SwitchLightOff()
	{
		var lights = GameObject.FindGameObjectsWithTag("light");
		foreach(var light in lights) light.GetComponent<light>().SwitchOff();
	}
	
}
