using UnityEngine;
using System.Collections;

public class boardElement : MonoBehaviour {
	
	public float finalX;
	public float finalY;
	public float finalZ;
	
	public float initX;
	public float initY;
	public float initZ;
	
	// Use this for initialization
	void Start () {
		transform.position.Set(initX, initY, initZ);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}