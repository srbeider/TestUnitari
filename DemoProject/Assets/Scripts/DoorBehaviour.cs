using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {
	
	private class Door{
		public Door(Transform door, Vector3 maxValue, float speed){
			DoorObj = door;
			MaxValue = maxValue;
			InitialPosition = door.position;
			Speed = speed;
			Debug.Log(speed);
		}
		
		private Transform DoorObj {get; set;}
		private Vector3 MaxValue {get; set;}
		private Vector3 InitialPosition {get; set;}
		public float Speed {get; set;}
		
		public void Update()
		{
			if(DoorObj.position.x <= InitialPosition.x + MaxValue.x)
			{
				DoorObj.Translate(new Vector3(Speed * Time.deltaTime, 0, 0), Space.Self);
				Debug.Log(Speed);
				
			}
			
		}
	}
	
	public Vector3 doorLeftMax = new Vector3(5, 0, 0);
	public Vector3 doorRightMax = new Vector3(-2,0,0);
	
	private bool openDoor = false;
	private bool closeDoor = true;
	public float speed = 1f;
	private Door doorLeft;
	private Door doorRight;
	
	// Use this for initialization
	void Start () {
		doorLeft = new Door(transform, doorLeftMax, speed);
		doorRight = new Door(transform.FindChild("DoorRight"), doorRightMax, speed * -1);
	}
	
	// Update is called once per frame
	void Update () {
		if (openDoor) {
			Debug.Log("Este no");
			doorLeft.Update();	
			Debug.Log("Ahora");
			doorRight.Update();
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		OpenDoor();
	}
		
	void OnCollisionExit(Collision collision)
	{
		CloseDoor();	
	}
		
	public void OpenDoor()
	{
		openDoor = true;
		closeDoor = false;
	}
		
	public void CloseDoor()
	{
		openDoor = false;
		closeDoor = true;
	}
}
