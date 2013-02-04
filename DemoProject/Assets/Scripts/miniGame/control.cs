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
	
	RaycastHit hit;
	
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
		if(Physics.Raycast(ray, out hit, 10))
		{
			CollisionDetected(hit.collider.gameObject);
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	void CollisionDetected(GameObject gobject)
	{
		if(gobject.tag.Equals("sparks")){
			print (gobject.name);
		}
	}
}
