using UnityEngine;
using System.Collections;

public class fader : MonoBehaviour {

	public float fadeInAtSecond = 1;
	public float fadeOutAtSecond = 6;
	public string nextScene = null;
	public float fadingVelocity = 0.25F;
	public bool automaticFadeOut = true;
	
	private float newAlpha = 1F;
	
	private enum FaderState
	{
		fadeOut,
		fadingIn,
		fadeIn,
		fadingOut,
		finished
	}
	
	private FaderState actualState = FaderState.fadeOut;
	
	void Start ()
	{
		var c = renderer.material.color;
		renderer.material.color = new Color(c.r, c.g, c.b, newAlpha);
	}
	
	void Update ()
	{
		if(Time.timeSinceLevelLoad >= fadeInAtSecond && actualState == FaderState.fadeOut)
		{
			//Fer fade in
			StartFadeIn();
		}
		else if(actualState == FaderState.fadingIn)
		{
			//Fent fade in
			FadeIn();
		}
		else if(Time.timeSinceLevelLoad >= fadeOutAtSecond && actualState == FaderState.fadeIn && automaticFadeOut)
		{
			//Fer fade out
			StartFadeOut();
		}
		else if(actualState == FaderState.fadingOut)
		{
			//Fent fade out
			FadeOut(true);
		}
		else if(actualState == FaderState.finished)
		{
			//Acabat
			Application.LoadLevel(nextScene);
		}
	}
	
	void FadeIn(){
		var c = renderer.material.color;
		newAlpha = c.a - (fadingVelocity * Time.deltaTime);
		renderer.material.color = new Color(c.r, c.g, c.b, newAlpha);
		
		if(newAlpha <= 0F) actualState = FaderState.fadeIn;
	}
	
	void FadeOut(bool finish){
		var c = renderer.material.color;
		newAlpha = c.a + (fadingVelocity * Time.deltaTime);
		renderer.material.color = new Color(c.r, c.g, c.b, newAlpha);
		
		if(finish){
			if(newAlpha >= 1F) actualState = FaderState.finished;
		}
		else{
			if(newAlpha >= 1F) actualState = FaderState.fadeOut;
		}
	}
	
	public void StartFadeIn()
	{
		actualState = FaderState.fadingIn;
	}
	
	public void StartFadeOut()
	{
		actualState = FaderState.fadingOut;
	}
}
