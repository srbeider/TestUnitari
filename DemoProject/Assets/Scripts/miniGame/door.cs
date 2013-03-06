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
	
	private sceneController controller;
	private bool playSound = false;
	
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ScriptsController").GetComponent<sceneController>();
		if(ActualState == state.Open)
		{
			OpenDoor(false);
		}
		else
		{
			CloseDoor(false);
		}
		
		playSound = true;
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
	
	public void ToogleDoor()
	{
		if(ActualState == state.Open)
		{
			CloseDoor();
		}
		else if(ActualState == state.Closed)
		{
			OpenDoor();
		}
	}
	
	private void OpenDoor()
	{
		OpenDoor(true);
	}
	
	private void OpenDoor(bool playSound)
	{
		ActualState = state.Open;
		controller.setDoorOpen(true);
		if(playSound) GameObject.Find ("/door/soundOpen").audio.Play();
	}
	
	private void CloseDoor()
	{
		CloseDoor(true);
	}
	
	private void CloseDoor(bool playSound)
	{
		ActualState = state.Closed;
		controller.setDoorOpen(false);
		if(playSound) GameObject.Find ("/door/soundClose").audio.Play();
	}
}