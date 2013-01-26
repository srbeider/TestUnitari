using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	
	public float velocity = 20F;
	public float ClosedAngle = 0F;
	public float OpenAngle = 90F;
	private float angle = 0F;
	public state ActualState = state.Closed;
	public enum state
	{
		Closed,
		Opening,
		Open,
		Closing
	}
	
	// Use this for initialization
	void Start () {
		if(ActualState == state.Open)
		{
			angle = OpenAngle;
		}
		else
		{
			angle = ClosedAngle;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(ActualState == state.Closed)
		{
		}
		else if(ActualState == state.Opening && angle < OpenAngle)
		{
			angle += velocity * Time.deltaTime;
			transform.Rotate(0, angle, 0);
		}
		else if(ActualState == state.Opening && angle >= OpenAngle)
		{
			angle = OpenAngle;
			ActualState = state.Open;
		}
		else if(ActualState == state.Open)
		{
		}
		else if(ActualState == state.Closing && angle > ClosedAngle)
		{
			angle -= velocity * Time.deltaTime;
			transform.Rotate(0, angle, 0);
		}
		else if(ActualState == state.Closing && angle <= ClosedAngle)
		{
			angle = ClosedAngle;
			ActualState = state.Closed;
		}
	}
	
	void OnMouseDown()
	{
		if(ActualState == state.Open)
		{
			ActualState = state.Closing;
		}
		else if(ActualState == state.Closed)
		{
			ActualState = state.Opening;
		}
		
		print (ActualState.ToString());
	}
}
