using System.Linq;
using UnityEngine;
using System.Collections;

public class TransitionOnPen : MonoBehaviour {
    protected ChaseMe[] chases;

	void Start () {
	    chases = FindObjectsOfType<ChaseMe>();
	}
	
	void Update () {
	    if (chases.All(c => !c.enabled)) {
	        FindObjectOfType<FocusThenTransition>().Focus();
            enabled = false;
	    }
	}
}
