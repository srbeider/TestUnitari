using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {
	
	private class Door{
		public Door(Transform door, Vector3 leftMaxValue, Vector3 rightMaxValue, float speed, ref bool openDoor){
			DoorObj = door;
			LeftMaxValue = leftMaxValue;
			RightMaxValue = rightMaxValue;
			InitialPosition = door.position;
			Speed = speed;
			OpenDoor = openDoor;
		}
		
		private Transform DoorObj {get; set;}
		private Vector3 LeftMaxValue {get; set;}
		private Vector3 RightMaxValue {get; set;}
		private Vector3 InitialPosition {get; set;}
		private float Speed {get; set;}
		public bool OpenDoor {get; set;}
		
		public void MoveLeft()
		{
			bool condition;
			
			if (OpenDoor) 
			{
				condition = DoorObj.position.x < InitialPosition.x + LeftMaxValue.x;
			}
			else
			{
				condition = DoorObj.position.x < InitialPosition.x;
			}
			if(condition)
			{
				DoorObj.Translate(new Vector3(Speed * Time.deltaTime, 0, 0), Space.Self);
			}
		}
		
		public void MoveRight(){
			bool condition;
			if (OpenDoor) 
			{
				condition = DoorObj.position.x > InitialPosition.x + RightMaxValue.x;
			}
			else
			{
				condition = DoorObj.position.x > InitialPosition.x;
			}
			
			if(condition)
			{
				DoorObj.Translate(new Vector3((Speed * -1) * Time.deltaTime, 0, 0), Space.Self);
			}
		}
	}
	
	public Vector3 doorLeftMax = new Vector3(5, 0, 0);
	public Vector3 doorRightMax = new Vector3(2,0,0);
	
	private bool openDoor = false;
	public float speedDoorLeft = 2f;
	public float speedDoorRight = 1f;
	private Door doorLeft;
	private Door doorRight;
	
	// Use this for initialization
	void Start () {
		doorLeft = new Door(transform.FindChild("DoorLeft"), doorLeftMax, transform.FindChild("DoorLeft").position, speedDoorLeft, ref openDoor);
		doorRight = new Door(transform.FindChild("DoorRight"), transform.FindChild("DoorRight").position, doorRightMax, speedDoorRight, ref openDoor);
	}
	
	// Update is called once per frame
	void Update () {
		doorLeft.OpenDoor = openDoor;
		doorRight.OpenDoor = openDoor;
		if (openDoor) {
			doorLeft.MoveLeft();	
			doorRight.MoveRight();
		}
		else {
			doorLeft.MoveRight();	
			doorRight.MoveLeft();
		}
	}
	
	void OnTriggerEnter(Collider collider)
	{
		OpenDoor();
	}
		
	void OnTriggerExit(Collider collider)
	{
		CloseDoor();	
	}
		
	public void OpenDoor()
	{
		openDoor = true;
	}
		
	public void CloseDoor()
	{
		openDoor = false;
	}
}
