using UnityEngine;
using System.Collections;

public class titleAnim : MonoBehaviour {
	
	public float velocity = 10;
	public float displacement = 0;
	public float startAtSecond = 0;
	public float stopAtSecond = 0;
	
	private float fadingVelocity = 0.1F;
	private float endPosition = 0;

	void Start ()
	{
		var c = renderer.material.color;
		renderer.material.color = new Color(c.r, c.g, c.b, 0F);
		endPosition = transform.position.x;
		transform.position = new Vector3(endPosition + displacement, transform.position.y, transform.position.z);
		
		if(transform.position.x > endPosition)
		{
			velocity = -velocity;
		}
	}
	
	void Update ()
	{
		if((startAtSecond >= stopAtSecond && Time.timeSinceLevelLoad > startAtSecond) ||
			(startAtSecond < stopAtSecond && Time.timeSinceLevelLoad > startAtSecond && Time.timeSinceLevelLoad < stopAtSecond))
		{
			transform.Translate(velocity * Time.deltaTime, 0, 0, Space.World);
			var c = renderer.material.color;
			float newAlpha = c.a + (fadingVelocity * Time.deltaTime);
			renderer.material.color = new Color(c.r, c.g, c.b, newAlpha);
		}
	}
}