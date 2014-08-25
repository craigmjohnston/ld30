using UnityEngine;
using System.Collections;

public class TransitionOnKey : MonoBehaviour {
    public KeyCode key;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key)) {
	        GetComponent<TransitionToScene>().Transition();
	        enabled = false;
	    }
	}
}
