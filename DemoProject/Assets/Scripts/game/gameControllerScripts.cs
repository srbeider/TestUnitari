using UnityEngine;
using System.Collections;

public class gameControllerScripts : MonoBehaviour {
	
	public bool miniGameResolved = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print ("miniGameResolved = " + miniGameResolved.ToString());
	}
	
	private static gameControllerScripts instance = null;
    public static gameControllerScripts ScriptsInstance {
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
