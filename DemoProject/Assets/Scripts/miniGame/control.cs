using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	
	public enum RotationAxes { XAndY = 0, X = 1, Y = 2 }
	public RotationAxes axes = RotationAxes.XAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	float rotationX = 0F;
	
	RaycastHit[] hits;
	GameObject lastCollided;
	
	private sceneController controller;
	
	// Use this for initialization
	void Start ()
	{
		controller = GameObject.Find("ScriptsController").GetComponent<sceneController>();
		if (rigidbody) rigidbody.freezeRotation = true;
	}
	
	void Update ()
	{
		if (axes == RotationAxes.XAndY)
		{
			rotationX += Input.GetAxis("Horizontal") * sensitivityX;
			rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
			
			rotationY += Input.GetAxis("Vertical") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.X)
		{
			transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Vertical") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		
		Ray ray = new Ray(this.transform.position, this.transform.forward);
		hits = Physics.RaycastAll(ray, 100);
		if(hits != null && hits.Length > 0)
		{
			foreach(var hit in hits)
			{
				if(hit.collider.gameObject.name.Equals("Paret"))
				{
					GameObject.Find("dot").transform.position = hit.point;
				}
			}
		}
		
		foreach(var hit in hits)
		{
			bool collisionResult = hit.collider.gameObject.layer == 8;
			ProcessCollision(collisionResult, hit);
		}
	}
	
	void ProcessCollision(bool isColliding, RaycastHit hit)
	{
		if(isColliding)
		{
			if(lastCollided != null && lastCollided.GetInstanceID() != hit.collider.gameObject.GetInstanceID())
			{
				lastCollided.GetComponentInChildren<guiControl>().HideGUI();
			}
			
			lastCollided = hit.collider.gameObject;
			var gControl = lastCollided.GetComponentInChildren<guiControl>();
			gControl.ShowGUI();
			if(Input.GetButtonUp("A")) gControl.OnActionA();
			if(Input.GetButtonUp("B")) gControl.OnActionB();
			//print (lastCollided.name);
		}
		else if(lastCollided != null)
		{
			lastCollided.GetComponentInChildren<guiControl>().HideGUI();
			lastCollided = null;
		}
	}
}