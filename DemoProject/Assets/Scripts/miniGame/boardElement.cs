using UnityEngine;
using System.Collections;

public class boardElement : MonoBehaviour {
	
	public float finalX;
	public float finalY;
	public float finalZ;
	
	public float cachedZ;
	
	public float initX;
	public float initY;
	public float initZ;
	
	enum state
	{
		catched,
		droped,
		positioned
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
		actualPosition = new Vector3(dot.position.x, dot.position.y, cachedZ);
	}
	
	// Update is called once per frame
	void Update () {
		if(actualState == state.catched)
		{			
			actualPosition = new Vector3(dot.position.x, dot.position.y, cachedZ);
			transform.position = actualPosition;
		}
	}
	
	public void Catch()
	{
		if(actualState == state.droped && controller.catchedObjects < 1)
		{
			controller.cachedId = name;
			actualState = state.catched;
			controller.catchedObjects++;
		}
	}
	
	public void Drop()
	{
		if(actualState == state.catched && controller.catchedObjects > 0)
		{
			var cachedId = controller.cachedId.Replace("board", string.Empty).Replace("sparks", string.Empty).Replace("_wire", string.Empty);
			
			string collisionId = string.Empty;
			
			if(controller.collisionId != null)
				collisionId = controller.collisionId.Replace("board", string.Empty).Replace("sparks", string.Empty).Replace("_wire", string.Empty);
			
			if(cachedId.Equals(collisionId))
			{
				actualState = state.positioned;
				transform.position = new Vector3(finalX, finalY, finalZ);
			}
			else
			{
				actualState = state.droped;
				transform.position = new Vector3(initX, initY, initZ);
			}
			
			controller.catchedObjects--;
			controller.cachedId = null;
		}
	}
}