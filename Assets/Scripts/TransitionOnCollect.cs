using System.Linq;
using UnityEngine;
using System.Collections;

public class TransitionOnCollect : MonoBehaviour {
    protected Collectable[] toCollect;

	void Start () {
	    toCollect = FindObjectsOfType<Collectable>();
	}
	
	void Update () {
	    if (toCollect.All(c => c == null)) {
	        var focus = FindObjectOfType<FocusThenTransition>();
	        if (focus != null) {
	            focus.Focus();
                FindObjectsOfType<ParticleSystem>().First(p => p.gameObject.name.Contains("Balloon")).Play();
	        } else {
	            GetComponent<TransitionToScene>().Transition();
                audio.Play();
	        }
	        enabled = false;
	    }
	}
}
