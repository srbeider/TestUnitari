using UnityEngine;
using System.Collections;

public class boardElement : MonoBehaviour {
	
	public float finalX;
	public float finalY;
	public float finalZ;
	
	public float initX;
	public float initY;
	public float initZ;
	
	enum state
	{
		catched,
		droped
	}
	
	state actualState;
	Transform dot;
	Vector3 actualPosition;
	sceneController controller;
	
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ScriptsController").GetComponent<sceneController>();
		transform.position.Set(initX, initY, initZ);
		actualState = state.droped;
		dot = GameObject.Find("dot").transform;
		actualPosition = new Vector3(dot.position.x, dot.position.y, initZ);
	}
	
	// Update is called once per frame
	void Update () {
		if(actualState == state.catched)
		{
			actualPosition = new Vector3(dot.position.x, dot.position.y, initZ);
			transform.position = actualPosition;
		}
	}
	
	public void Catch()
	{
		if(actualState == state.droped && controller.catchedObjects < 1)
		{
			actualState = state.catched;
			controller.catchedObjects++;
		}
	}
	
	public void Drop()
	{
		if(actualState == state.catched && controller.catchedObjects > 0)
		{
			actualState = state.droped;
			controller.catchedObjects--;
			transform.position = new Vector3(initX, initY, initZ);
		}
	}
}