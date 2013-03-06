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
		
		if(GameObject.Find ("GameController").GetComponent<gameControllerScripts>().miniGameResolved)
		{
			SetPlaced();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(actualState == state.catched)
		{			
			actualPosition = new Vector3(dot.position.x, dot.position.y, cachedZ);
			transform.position = actualPosition;
			if(Input.GetButtonUp("B")) Drop ();
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
			actualState = state.droped;
			transform.position = new Vector3(initX, initY, initZ);
			controller.catchedObjects--;
			controller.cachedId = null;
		}
	}
	
	public void Place()
	{
		if(actualState == state.catched && controller.catchedObjects > 0)
		{
			actualState = state.positioned;
			transform.position = new Vector3(finalX, finalY, finalZ);
			controller.catchedObjects--;
			controller.cachedId = null;
			audio.Play();
			
			controller.resolvedObjects++;
			if(controller.resolvedObjects >= 5)
			{
				GameObject.Find ("minigameSuccesSound1").audio.Play();
				GameObject.Find ("minigameSuccesSound2").audio.Play();
				GameObject.Find ("light").GetComponent<light>().SwitchOn();
				GameObject.Find ("GameController").GetComponent<gameControllerScripts>().miniGameResolved = true;
			}
		}
	}
	
	public void SetPlaced()
	{
		actualState = state.positioned;
		transform.position = new Vector3(finalX, finalY, finalZ);
		controller.resolvedObjects++;
	}
}