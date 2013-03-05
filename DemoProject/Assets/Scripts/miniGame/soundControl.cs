using UnityEngine;
using System.Collections;

public class soundControl : MonoBehaviour {

	public int playPosibility;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Random.Range(1, playPosibility) == 1)
		{
			var noisesResult = GameObject.FindGameObjectsWithTag("noise");
			var noise = noisesResult[Random.Range(0, noisesResult.Length)].audio;
			
			if(!noise.isPlaying) noise.Play();
		}
	}
	
	private static soundControl instance = null;
    public static soundControl ScriptsInstance {
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
}
