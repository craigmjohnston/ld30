using UnityEngine;
using System.Collections;

public class HideAfterTransition : MonoBehaviour {
    protected dfPanel panel;

	// Use this for initialization
	void Start () {
        panel = GetComponent<dfPanel>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (panel.BackgroundColor.a == 0) {
	        panel.IsVisible = false;
	    }
	}
}
