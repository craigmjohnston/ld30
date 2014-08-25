using UnityEngine;
using System.Collections;

public class OpenDoorOnKey : MonoBehaviour {
    public KeyCode key;
    public float maxDistance;
    public LayerMask doorMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key)) {
	        RaycastHit hitInfo;
	        if (Physics.Raycast(Camera.main.ViewportPointToRay(Vector2.one*0.5f), out hitInfo, maxDistance, doorMask)) {
	            hitInfo.collider.gameObject.GetComponent<ToggleSlide>().Toggle();
                if (hitInfo.collider.gameObject.name.Contains("Horizon")) {
                    hitInfo.collider.gameObject.GetComponent<TransitionToScene>().Transition();
	            }
	        }
	    }
	}
}