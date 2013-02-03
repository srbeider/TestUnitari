using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {
	
	public enum FadingState
	{
		FadingOut,
		Muted,
		FadingIn,
		Unmuted
	}
	
	float fadingVelocity;
	FadingState actualState;
	
	// Use this for initialization
	void Start () {
		actualState = FadingState.Unmuted;
	}
	
	// Update is called once per frame
	void Update () {
		if(actualState == FadingState.FadingOut && audio.volume > 0)
		{
			audio.volume -= fadingVelocity * Time.deltaTime;
		}
		else if(actualState == FadingState.FadingOut && audio.volume <= 0)
		{
			actualState = FadingState.Muted;
			audio.volume = 0;
		}
		else if(actualState == FadingState.FadingIn && audio.volume < 1)
		{
			audio.volume += fadingVelocity * Time.deltaTime;
		}
		else if(actualState == FadingState.FadingIn && audio.volume >= 1)
		{
			actualState = FadingState.Unmuted;
			audio.volume = 1;
		}
	}

    private static music instance = null;
    public static music MusicInstance {
        get { return instance; }
    }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void FadeOutMusic(float duration)
	{
		fadingVelocity = audio.volume / duration;
		actualState = FadingState.FadingOut;
	}

    public void FadeInMusic(float duration)
	{
		fadingVelocity = audio.volume / duration;
		actualState = FadingState.FadingIn;
	}
}